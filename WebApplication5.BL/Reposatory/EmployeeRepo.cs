

namespace WebApplication5.BL.Reposatory;

   public class EmployeeRepo:IEmployee
    {
        private readonly DataContext db;
        public EmployeeRepo(DataContext db)
        {
            this.db = db;
        }
        //this method to add employee to database
        public void create(Employee emp)
        {
            db.employees.Add(emp);
            db.SaveChanges();
        }
        //this method to delete employee from database
        public void delete(Employee emp)
        {
            db.employees.Remove(emp);
            db.SaveChanges();
        }
        //this method to get all employees from database based on filter
        public IEnumerable<Employee> getbyfilter(Func<Employee, bool> filter=null)
        {
            if (filter == null)
            {
                var data = db.employees.Include("Department").Select(a => a);
                return data;
            }
            else{
                var data = db.employees.Include("Department").Where(filter);
                return data;
            }
        }
        //this method to get  employee from database based on id
        public Employee getbyid(int id)
        {
            var data = db.employees.Find(id);
            return data;
        }
        //this method to get all employess based on filter
        public IEnumerable<Employee> search(Func<Employee, bool> filter )
        {
            var data = db.employees.Include("Department").Where(filter);
            return data;
        }
        //this method to update employee
        //emp contain new values
        public void update(Employee emp)
        {
            db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }

