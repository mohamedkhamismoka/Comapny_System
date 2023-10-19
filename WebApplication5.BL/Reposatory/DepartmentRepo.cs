using System.Collections.Generic;
using System.Linq;

using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.Reposatory;

    public class DepartmentRepo : IDepartment
    {
       readonly private DataContext db;
        
        public DepartmentRepo(DataContext db)
        {
            this.db = db;
         
        }
        //this method to add department to database
        public void create(Department dep)
        {
            db.departments.Add(dep);
            db.SaveChanges();
        }
        //this method to delete department from database
        public void delete(Department dep)
        {
            db.departments.Remove(dep);
            db.SaveChanges();
        }
        //this method to get all departments from  database
        public IEnumerable<Department> get()
        {
            var data = db.departments.Select(a => a);
            return data;

        }
        //this method to get department from database based on id
        public Department getbyid(int id)
        {
            var data = db.departments.Find(id);
            return data;
        }
        //this method to update department in database 
        public void update(Department dep)
        {
            db.Entry(dep).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }

