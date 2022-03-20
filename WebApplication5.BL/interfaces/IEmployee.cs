using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.interfaces
{
   public  interface IEmployee
    {
        IEnumerable<Employee> get(Func<Employee, bool> filter = null);
        IEnumerable<Employee> search(Func<Employee, bool> filter);
        Employee getbyid(int id);
        void create(Employee emp);
        void update(Employee emp);
        void delete(Employee emp);

    }
}
