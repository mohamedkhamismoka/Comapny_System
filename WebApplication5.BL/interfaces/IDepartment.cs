using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.DAL.Database;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.interfaces
{
    public interface IDepartment
    {
        IEnumerable<Department> get();
        Department getbyid(int id);
        void create(Department dep);
        void update(Department dep);
        void delete(Department dep);



    }
}
