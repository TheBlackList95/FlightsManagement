using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuiviDesVols.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le mot de passe et sa confirmation ne sont pas identiques")]
        [Required(ErrorMessage = "Confirmez le mot de passe")]
        public string ConfirmPassword { get; set; }
    }
}
