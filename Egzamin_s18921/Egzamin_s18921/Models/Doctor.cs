using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_s18921.Controllers.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Email]
        public string Email { get; set; }
    }
}
