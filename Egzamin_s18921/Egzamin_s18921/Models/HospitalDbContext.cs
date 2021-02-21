using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Egzamin_s18921.Controllers.Models
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Prescription> Prescription { get; set; }

        public DbSet<PrescriptionMedicament> Prescription_Medicament { get; set; }

        public HospitalDbContext() { }

        public HospitalDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PrescriptionMedicament>().HasKey(k => new { k.IdMedicament, k.IdPrescription });

            List<Doctor> listDoctors = new List<Doctor>();
            listDoctors.Add(new Doctor {Id=1, IdDoctor = 1, FirstName = "Jan", LastName = "Kowalski", Email = "123@g.com" });
            listDoctors.Add(new Doctor { Id = 2, IdDoctor = 2, FirstName = "Kuba", LastName = "Nowak", Email = "1243@g.com" });
            listDoctors.Add(new Doctor { Id = 3, IdDoctor = 3, FirstName = "Kan", LastName = "Bowal", Email = "1235@g.com" });
            modelBuilder.Entity<Doctor>().HasData(listDoctors);

            List<Medicament> listMedicaments = new List<Medicament>();
            listMedicaments.Add(new Medicament { IdMedicament = 1, Name = "medi1", Description = "desc1", Type = "m1" });
            listMedicaments.Add(new Medicament { IdMedicament = 2, Name = "medi2", Description = "desc2", Type = "m2" });
            listMedicaments.Add(new Medicament { IdMedicament = 3, Name = "medi3", Description = "desc3", Type = "m3" });
            modelBuilder.Entity<Medicament>().HasData(listMedicaments);

            List<Patient> listPatients = new List<Patient>();
            listPatients.Add(new Patient { IdPatient = 1, FirstName = "Bogumił", LastName = "Biedrzycki", Birthdate = Convert.ToDateTime("2021-01-01") });
            listPatients.Add(new Patient { IdPatient = 2, FirstName = "Jakub", LastName = "Kowalski", Birthdate = Convert.ToDateTime("2021-02-01") });
            listPatients.Add(new Patient { IdPatient = 3, FirstName = "Wiotr", LastName = "Wavy", Birthdate = Convert.ToDateTime("2021-03-01") });
            modelBuilder.Entity<Patient>().HasData(listPatients);

            List<Prescription> listPrescriptions = new List<Prescription>();
            listPrescriptions.Add(new Prescription { IdPrescription = 1, Date = Convert.ToDateTime("2021-01-01"), DueDate = Convert.ToDateTime("2020-01-01"), IdPatient = 0, IdDoctor = 0 });
            listPrescriptions.Add(new Prescription { IdPrescription = 2, Date = Convert.ToDateTime("2020-02-02"), DueDate = Convert.ToDateTime("2021-01-01"), IdPatient = 1, IdDoctor = 1 });
            listPrescriptions.Add(new Prescription { IdPrescription = 3, Date = Convert.ToDateTime("2011-03-02"), DueDate = Convert.ToDateTime("2021-03-05"), IdPatient = 2, IdDoctor = 2 });
            modelBuilder.Entity<Prescription>().HasData(listPrescriptions);

            List<PrescriptionMedicament> listPrescriptionMedicament = new List<PrescriptionMedicament>();
            listPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 50, Details = "d1" });
            listPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 40, Details = "d2" });
            listPrescriptionMedicament.Add(new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 3, Dose = 10, Details = "d3" });
            modelBuilder.Entity<PrescriptionMedicament>().HasData(listPrescriptionMedicament);
        }
    }
}
