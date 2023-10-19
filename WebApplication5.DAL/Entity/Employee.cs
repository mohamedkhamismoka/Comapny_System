
namespace WebApplication5.DAL.Entity;

   public class Employee
    {
  
        public int id { get; set; }
       
        public string name { get; set; }
        public string address { get; set; }
        
        public int salary { get; set; }
    [Column(TypeName ="Date")]
        public DateTime Hiredate { get; set; }
    [Column(TypeName = "Date")]
    public DateTime Creationdate { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

        public long phone { get; set; }
        public int DepartmentId { get; set; }
      
        [ForeignKey("DepartmentId")]
        public  Department Department { get; set; }
        public string cvname { get; set; }
        public string imgname { get; set; }

        public virtual  IEnumerable<Works_For> work { get; set; }

    
}
