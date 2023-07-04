


namespace WebApplication5.BL.VM;

   public  class ResetPasswordVM
    {
        public string ?password { get; set; }
        [Required(ErrorMessage = "password required")]
        [MinLength(6, ErrorMessage = "min Length 6 Characters")]
        [Compare("password", ErrorMessage = "Not Matched Password")]
        public string? confirmpassword { get; set; }
        public string? mail { get; set; }
        public string ?Token { get; set; }
    }

