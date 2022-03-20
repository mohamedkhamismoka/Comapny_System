using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.DAL.Entity
{
    public class Project
    {
        [Key]
        public int id{ get; set; }
       
        public string name{ get; set; }
     
        public string location{ get; set; }


        public int Dnum { get; set; }
       
        public DateTime Startdate { get; set; }
       
        public DateTime Finishdate { get; set; }

        [ForeignKey("Dnum")]
        public Department Department { get; set; }
        public string state { get; set; }
        public IEnumerable<Works_For> work { get; set; }
    }
}
