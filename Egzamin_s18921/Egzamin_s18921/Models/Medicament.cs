using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_s18921.Controllers.Models
{
    public class Medicament
    {
        [Key]
        public int IdMedicament { get; set; }
        public List<Prescription> Prescription { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
