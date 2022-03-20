using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.BL.VM
{
   public class MailVM
    {
        [Required(ErrorMessage ="Mail Address is Required")]
        public string mail { get; set; }
        [Required(ErrorMessage = "password is Required")]
        public string password { get; set; }
        [Required(ErrorMessage = "Message is Required")]
        public string body { get; set; }
        [Required(ErrorMessage = "title is Required")]
        public string title { get; set; }
    }
}
