


namespace WebApplication5.DAL.Entity;

   public class Department
    {
        public int id { get; set; }
        public String name { get; set; }
        public  IEnumerable<Employee> employees { get; set; }
        public  IEnumerable<Project> projects { get; set; }
    }

