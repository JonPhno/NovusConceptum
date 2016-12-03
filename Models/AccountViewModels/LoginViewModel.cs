using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NovusConceptum.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
