using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.DAL.Extend
{
    
   public class ApplicationUser:IdentityUser
    {
      
        public bool isAgreed { get; set; }
    }
}
