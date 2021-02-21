using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_s18921.Controllers.Models
{
    public class Prescription
    {
        [Key]
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        [ForeignKey("IdPatient")]
        public int IdPatient { get; set; }
        [ForeignKey("IdDoctor")]
        public int IdDoctor { get; set; }
    }
}
