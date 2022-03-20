using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.DAL.Entity
{
   public class Department
    {[Key]
        public int id { get; set; }
        public String name { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public IEnumerable<Project> projects { get; set; }
    }
}
