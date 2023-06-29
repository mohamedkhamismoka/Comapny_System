


namespace WebApplication5.BL.VM;

   public class MailVM
    {
        [Required(ErrorMessage ="Mail Address is Required")]
        public string mail { get; set; }
        
        [Required(ErrorMessage = "Message is Required")]
        public string body { get; set; }
  
    }

