using APBD10SOL.Data;
using APBD10SOL.Models;
using APBD10SOL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace APBD10SOL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly DatabaseContext _context;
    private readonly IDbService _dbService;

    public PatientsController(DatabaseContext context, IDbService dbService)
    {
        _context = context;
        _dbService = dbService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
    {
        var patients = await _context.Patients.Include(p => p.Prescriptions).ToListAsync();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };

        var patientsWithPrescriptions = patients.Select(p => new
        {
            idPatient = p.IdPatient,
            firstName = p.FirstName,
            lastName = p.LastName,
            birthDay = p.BirthDay,
            prescriptions = p.Prescriptions
        });

        return Ok(JsonSerializer.Serialize(patientsWithPrescriptions, options));
    }




    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatient(int id)
    {
        var patient = await _context.Patients.FindAsync(id);
        
        Console.WriteLine(String.Join(",", patient.Prescriptions));

        if (_dbService.DoesPatientExistAsync(id) == null)
        {
            return NotFound();
        }

        return patient;
    }
    
    
}