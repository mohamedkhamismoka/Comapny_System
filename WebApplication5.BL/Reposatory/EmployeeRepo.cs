using Microsoft.EntityFrameworkCore;
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
   public class EmployeeRepo:IEmployee
    {
        private readonly DataContext d;
        public EmployeeRepo(DataContext d)
        {
            this.d = d;
        }
        //this method to add employee to database
        public void create(Employee emp)
        {
            d.employees.Add(emp);
            d.SaveChanges();
        }
        //this method to delete employee from database
        public void delete(Employee emp)
        {
            d.employees.Remove(emp);
            d.SaveChanges();
        }
        //this method to get all employees from database based on filter
        public IEnumerable<Employee> get(Func<Employee, bool> filter=null)
        {
            if (filter == null)
            {
                var data = d.employees.Include("Department").Select(a => a);
                return data;
            }
            else{
                var data = d.employees.Include("Department").Where(filter);
                return data;
            }
        }
        //this method to get  employee from database based on id
        public Employee getbyid(int id)
        {
            var data = d.employees.Find(id);
            return data;
        }
        //this method to get all employess based on filter
        public IEnumerable<Employee> search(Func<Employee, bool> filter )
        {
            var data = d.employees.Include("Department").Where(filter);
            return data;
        }
        //this method to update employee
        //emp contain new values
        public void update(Employee emp)
        {
            d.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            d.SaveChanges();
        }
    }
}
