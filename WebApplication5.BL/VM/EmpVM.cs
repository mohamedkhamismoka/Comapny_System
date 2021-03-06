using Microsoft.AspNetCore.Http;
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
   public class EmpVM
    {

  
        public int id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "min length is 3")]
        public string name { get; set; }
        [Required(ErrorMessage ="Address required")]
        [RegularExpression("[0-9]{2,5}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}-[a-zA-Z]{1,50}", ErrorMessage = "address must like 12-Street name-cityname-countryname")]
        public string address { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        public int salary { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Hiredate { get; set; }
        public DateTime Creationdate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter valid phone number")]
        public long phone { get; set; }

        [Required(ErrorMessage ="Choose Department")]
        public int departmentid { get; set; }


        public Department Department { get; set; }

        public string cvname { get; set; }
        public string imgname { get; set; }

        public IFormFile cv { get; set; }

        public IFormFile img { get; set; }


        public EmpVM()
        {
            isActive = false;
            isDeleted = false;
            
            Creationdate = DateTime.Now;

        }
    }
}
