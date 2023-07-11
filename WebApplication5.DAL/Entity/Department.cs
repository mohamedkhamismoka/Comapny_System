


namespace WebApplication5.DAL.Entity;

   public class Department
    {[Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public String name { get; set; }
        public virtual IEnumerable<Employee> employees { get; set; }
        public virtual IEnumerable<Project> projects { get; set; }
    }

