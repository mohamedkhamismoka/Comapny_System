using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace WebApplication5.BL.VM
{
    public class LoginVM
    {
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email Is Required")]

        public string mail { get; set; }

        [Required(ErrorMessage = "password required")]
        [MinLength(6, ErrorMessage = "min Length 6 Characters")]
        public string password { get; set; }
        public bool isAgreed { get; set; }

        public bool IsSelected { get; set; }

        public string? ReturnUrl { get; set; }

        public IEnumerable<AuthenticationScheme> ExternalLogin { get; set; }
    }
}
