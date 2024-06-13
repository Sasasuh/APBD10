using System.ComponentModel.DataAnnotations;

namespace APBD10SOL.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    public string FirstName { get; set; }
    [MaxLength(100)]

    public string LastName { get; set; }
    [MaxLength(100)]

    public string email { get; set; }

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}