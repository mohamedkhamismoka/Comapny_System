using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.DAL.Entity
{
    public class Works_For {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
        public int id { get; set; }
        public int Project_id { get; set; }

    
        public int Employee_id { get; set; }
        public int hours { get; set; }
        [ForeignKey("Employee_id")]
        public Employee Employee { get; set; }

        [ForeignKey("Project_id")]
        public Project Project { get; set; }
        
        public int Dnum { get; set; }
    }
}
