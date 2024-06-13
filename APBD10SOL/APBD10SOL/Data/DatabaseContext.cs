using APBD10SOL.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD10SOL.Data;

public class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor
            {
                IdDoctor = 1,
                FirstName = "Adam",
                LastName = "Nowak",
                email = "adamnowak@gmail.com"
            },
            new Doctor
            {
                IdDoctor = 2,
                FirstName = "Aleksandra",
                LastName = "Wisniewska",
                email = "aleksandrawisniewska@gmail.com"
            }
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient
            {
                IdPatient = 1,
                FirstName = "Anna",
                LastName = "Nowak",
                BirthDay = DateTime.Parse("1985-05-15")
            },
            new Patient
            {
                IdPatient = 2,
                FirstName = "Adam",
                LastName = "Nowak",
                BirthDay = DateTime.Parse("1986-04-12")
            }
        });

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament
            {
                IdMedicament = 1,
                Name = "Aspirin",
                Description = "Pain reliever",
                Type = "Pain killer"
            },
            new Medicament
            {
                IdMedicament = 2,
                Name = "Ibuprofen",
                Description = "Anti-imflammatory",
                Type = "Pain killer"
            },
            new Medicament
            {
                IdMedicament = 3,
                Name = "Paracetamol",
                Description = "Pain reliever",
                Type = "Mashrooms :)"
            }
        });
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription
            {
                IdPrescription = 1,
                Date = DateTime.Parse("2024-05-28"),
                DueDate = DateTime.Parse("2024-05-29"),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription
            {
                IdPrescription = 2,
                Date = DateTime.Parse("2024-02-23"),
                DueDate = DateTime.Parse("2024-03-25"),
                IdPatient = 2,
                IdDoctor = 2,
            }
        });
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "Details soon.."
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 1,
                Dose = 4,
                Details = "Details soon..2"
            },
            new PrescriptionMedicament
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 3,
                Details = "Details soon..3"
            }
        });
    }
}