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
   public class ProjectVM
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="name is required")]
        public string name { get; set; }
        [Required(ErrorMessage = "location is required")]
        public string location { get; set; }
        [Required(ErrorMessage ="Choose Department")]
        public int Dnum { get; set; }
        [Required(ErrorMessage = "start date is required")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Startdate { get; set; }
        [Required(ErrorMessage = "Finish date is required")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime Finishdate { get; set; }

        [ForeignKey("Dnum")]
        public Department Department { get; set; }

        public string state { get; set; }
        public ProjectVM()
        {
           
        }
    }
}
