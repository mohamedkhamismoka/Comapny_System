

namespace WebApplication5.DAL.Entity;

    public class Works_For {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
   
        public int id { get; set; }
        public int ?projectId { get; set; }

    
        public int? employeeId { get; set; }
        public int hours { get; set; }

        public virtual Employee Employee { get; set; }

      
        public virtual Project Project { get; set; }
        
        public int Dnum { get; set; }
    
}
