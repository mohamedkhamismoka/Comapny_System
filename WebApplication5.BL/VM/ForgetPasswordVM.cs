

namespace WebApplication5.BL.VM;

   public class ForgetPasswordVM
    {
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Email Is Required")]

        public string? mail { get; set; }
    }

