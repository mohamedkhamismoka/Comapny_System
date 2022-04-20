using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.VM
{
   public  class DeptVM
    {
       
        public int id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [MinLength(2,ErrorMessage ="min length is 2")]
        public String name { get; set; }
        public IEnumerable<Employee> employees { get; set; }
        public IEnumerable<Project> projects { get; set; }
    }
}
