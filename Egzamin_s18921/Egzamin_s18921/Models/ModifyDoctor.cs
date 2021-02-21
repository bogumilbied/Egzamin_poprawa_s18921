using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Egzamin_s18921.Controllerscw11.Models
{
    public class ModifyDoctor
    {
        [Required]
        public int Id { get; set; }
        public string IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Email]
        public string Email { get; set; }
    }
}
