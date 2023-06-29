

namespace WebApplication5.BL.VM;

   public class RegisterVM
    {
        [EmailAddress(ErrorMessage = "Invalid username type your mail")]
        [Required(ErrorMessage = "username(Email) Is Required")]

        public string mail { get; set; }

        [Required(ErrorMessage = "password required")]
        [MinLength(6, ErrorMessage = "min Length 6 Characters")]
        public string password { get; set; }
        [Required(ErrorMessage = "password required")]
        [MinLength(6, ErrorMessage = "min Length 6 Characters")]
        [Compare("password", ErrorMessage = "Not Matched Password")]
        public string confirmpassword { get; set; }
        public bool isAgreed { get; set; }

 

    }

