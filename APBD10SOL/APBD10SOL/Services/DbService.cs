using APBD10SOL.Data;
using Microsoft.EntityFrameworkCore;

namespace APBD10SOL.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatientExistAsync(int id)
    {
        return await _context.Patients.AnyAsync(e => e.IdPatient == id);
    }

    public async Task<bool> DoesDoctorExistAsync(int id)
    {
        return await _context.Doctors.AnyAsync(e => e.IdDoctor == id);
    }

    public async Task<bool> DoesMedicamentExistAsync(int id)
    {
        return await _context.Medicaments.AnyAsync(e => e.IdMedicament == id);
    }

    public async Task<bool> DoesPrescriptionExistAsync(int id)
    {
        return await _context.Prescriptions.AnyAsync(e => e.IdPrescription == id);
    }
}