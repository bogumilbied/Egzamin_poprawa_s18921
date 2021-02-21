using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Egzamin_s18921.Controllers.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egzamin_s18921.Controllers
{
    public class HospitalController : ControllerBase
    {
        private readonly HospitalDbContext hospitalDbContext;

        public HospitalController(HospitalDbContext hospitalDbContext)
        {
            this.hospitalDbContext = hospitalDbContext;
        }
        //Błędy w kompilacji
        /*
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(hospitalDbContext.Prescriptions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(hospitalDbContext.Prescriptions.Where(p => p.Id == id).Include(p => p.Medicaments).ThenInclude(pm => pm.Medicament).FirstOrDefault());
        }
        */
        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            if (hospitalDbContext.Patient.Where(d => d.IdPatient == id).Any())
            {

                var presc = hospitalDbContext.Prescription.SingleOrDefault(d => d.IdPatient == id);
                var prescmod = hospitalDbContext.Prescription_Medicament.Where(d => d.IdPrescription == presc.IdPrescription).ToList();
                var patient = hospitalDbContext.Patient.SingleOrDefault(d => d.IdPatient == id);
                foreach (var item in prescmod)
                {
                    hospitalDbContext.Prescription_Medicament.Remove(item);
                }
                hospitalDbContext.Prescription.Remove(presc);
                hospitalDbContext.Patient.Remove(patient);
                hospitalDbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        public IActionResult GetPrescription(int id)
        {
            if (hospitalDbContext.Prescription.Where(d => d.IdPrescription == id).Any())
            {
                var medicament = hospitalDbContext.Prescription_Medicament
                    .Include(d => d.IdMedicament)
                    .Where(d => d.IdPrescription == id).Select(d => d.IdMedicament)
                    .ToList();
                var prescription = hospitalDbContext.Medicament.SingleOrDefault(d => d.IdMedicament == id);
                return Ok(prescription);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            if (hospitalDbContext.Doctor.Where(d => d.IdDoctor == id).Any())
            {
                var doctor = hospitalDbContext.Doctor.SingleOrDefault(d => d.IdDoctor == id);
                hospitalDbContext.Doctor.Remove(doctor);
                hospitalDbContext.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            if (hospitalDbContext.Doctor.Where(d => d.IdDoctor == id).Any())
            {
                var doctor = hospitalDbContext.Doctor.SingleOrDefault(d => d.IdDoctor == id);
                return Ok(doctor);
            }
            return NotFound();
        }


        [HttpGet("{id}")]
        public IActionResult GetMedicament(int id)
        {
            if (hospitalDbContext.Medicament.Where(d => d.IdMedicament == id).Any())
            {
                var prescription = hospitalDbContext.Prescription_Medicament
                    .Include(d=>d.Prescription)
                    .Where(d => d.IdMedicament == id).Select(d=>d.Prescription)
                    .OrderBy(d=>d.Date).ToList();
                var medicament = hospitalDbContext.Medicament.SingleOrDefault(d => d.IdMedicament == id);
                medicament.Prescription = prescription;
                return Ok(medicament);
            }
            return NotFound();
        }
    }
}