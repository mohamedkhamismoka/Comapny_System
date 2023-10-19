

namespace WebApplication5.DAL.Entity;

    public class Works_For {
       
       
        public int hours { get; set; }



    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public  Project Project { get; set; }

    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public  Employee Employee { get; set; }

      
        
        
       
    
}
