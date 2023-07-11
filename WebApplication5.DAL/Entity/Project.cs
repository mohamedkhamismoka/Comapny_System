
namespace WebApplication5.DAL.Entity;

    public class Project { 
    
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id{ get; set; }
       
        public string name{ get; set; }
     
        public string location{ get; set; }


        public int Dnum { get; set; }
       
        public DateTime Startdate { get; set; }
       
        public DateTime Finishdate { get; set; }

        [ForeignKey("Dnum")]
        public virtual Department Department { get; set; }
        public string state { get; set; }
        public virtual IEnumerable<Works_For> work { get; set; }
    
}
