using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesterin.Services.Models.Accounts
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email should not empty")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password should not empty")]
        public string Password { get; set; }
    }
}
