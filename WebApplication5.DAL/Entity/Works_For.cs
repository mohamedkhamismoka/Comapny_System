

namespace WebApplication5.DAL.Entity;

    public class Works_For {
       
       
        public int hours { get; set; }



    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public virtual Project Project { get; set; }

    public int EmployeeId { get; set; }
    [ForeignKey("EmployeeId")]
    public virtual Employee Employee { get; set; }

      
        
        
       
    
}
