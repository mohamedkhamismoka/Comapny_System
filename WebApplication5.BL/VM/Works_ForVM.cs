using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.VM
{
    public class Works_ForVM
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    
        public int id { get; set; }
        [Required(ErrorMessage ="hours Required")]
        [Range(0,100,ErrorMessage ="Value out of range")]
        public int hours { get; set; }
     
        [ForeignKey("Employee_id")]
      
        public Employee Employee { get; set; }


        [Required(ErrorMessage = "Employee required")]
      
        public int Employee_id { get; set; }

        [ForeignKey("Project_id")]
       
        public Project Project { get; set; }

        [Required(ErrorMessage =" Choose Project ")]
     
        [Range(1, long.MaxValue, ErrorMessage = "Choose Project")]
        public int? Project_id { get; set; }

        [ForeignKey("Dnum")]
     
        public Department dept { get; set; }
        [Required(ErrorMessage = "Choose Department")]
        [Display(Name = "Department")]
        [Range(1,long.MaxValue,ErrorMessage = "Choose Department")]
        public int? Dnum { get; set; }



        public int? old_Project_id { get; set; }

    }
}
