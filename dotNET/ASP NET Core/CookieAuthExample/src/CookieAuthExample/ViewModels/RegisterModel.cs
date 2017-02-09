using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CookieAuthExample.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email field could not be left blank")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password field could not be left blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password confirmation is incorrect")]
        public string ConfirmPassword { get; set; }
    }
}
