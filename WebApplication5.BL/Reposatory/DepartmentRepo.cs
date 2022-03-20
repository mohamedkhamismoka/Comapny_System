using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BL.interfaces;
using WebApplication5.DAL.Database;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.Reposatory
{
    public class DepartmentRepo : IDepartment
    {
       readonly private DataContext d;
        
        public DepartmentRepo(DataContext d)
        {
            this.d = d;
         
        }
        //this method to add department to database
        public void create(Department dep)
        {
            d.departments.Add(dep);
            d.SaveChanges();
        }
        //this method to delete department from database
        public void delete(Department dep)
        {
            d.departments.Remove(dep);
            d.SaveChanges();
        }
        //this method to get all departments from  database
        public IEnumerable<Department> get()
        {
            var data = d.departments.Select(a => a);
            return data;

        }
        //this method to get department from database based on id
        public Department getbyid(int id)
        {
            var data = d.departments.Find(id);
            return data;
        }
        //this method to update department in database 
        public void update(Department dep)
        {
            d.Entry(dep).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            d.SaveChanges();
        }
    }
}
