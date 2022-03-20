using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication5.DAL.Entity
{
   public class Employee
    {
        [Key]
        public int id { get; set; }
       
        public string name { get; set; }
        public string address { get; set; }
        
        public int salary { get; set; }
        public DateTime Hiredate { get; set; }
        public DateTime Creationdate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        public long phone { get; set; }
        public int departmentid { get; set; }
        [ForeignKey("departmentid")]
        [JsonIgnore]
        public Department Department { get; set; }
        public string cvname { get; set; }
        public string imgname { get; set; }

        public IEnumerable<Works_For> work { get; set; }

    }
}
