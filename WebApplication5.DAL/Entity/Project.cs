
namespace WebApplication5.DAL.Entity;

    public class Project {

    
        public int id{ get; set; }
       
        public string name{ get; set; }
     
        public string location{ get; set; }


        public int DepartmentId { get; set; }
       
        public DateTime Startdate { get; set; }
       
        public DateTime Finishdate { get; set; }
    [ForeignKey("DepartmentId")]

        public virtual Department Department { get; set; }
        public string state { get; set; }
        public virtual IEnumerable<Works_For> work { get; set; }
    
}
