using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'email est obligatoire")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        public string Password { get; set; }

        public bool Remember { get; set; }
    }
}
