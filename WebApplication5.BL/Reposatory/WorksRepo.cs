using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.BL.interfaces;
using WebApplication5.BL.VM;
using WebApplication5.DAL.Database;
using WebApplication5.DAL.Entity;

namespace WebApplication5.BL.Reposatory
{
    public class WorksRepo : IWorks_For
    {
        readonly private DataContext d;
        public WorksRepo(DataContext d)
        {
            this.d = d;

        }
        //this method get all records from database based on filter from works entity
        public IEnumerable<Works_For> getFilter(Func<Works_For, bool> filter = null)
        {
            if (filter == null)
            {
                var data = d.works.Select(a => a);
                return data;
            }
            else
            {
                var data = d.works.Include("Employee").Include("Project").Where(filter);
                return data;
            }
        }
        //this method add record to works entity in database
        public void create(Works_For work)
        {
            d.works.Add(work);
            d.SaveChanges();
        }

        //this method delete record from works entity in database
        public void delete(Works_For work)
        {
            d.works.Remove(work);
            d.SaveChanges();
        }
        //this method get all records from database 
        public IEnumerable<Works_For> get()
        {
           var data= d.works.Select(a => a);
            return data;
        }

        //public void update(Works_For work, int id,int oldproject) {
        //    delete(work);
        //    var commandText2 = "INSERT into works values (@proid, @empid, @hours,@Dnum)";
        //    var proid = new SqlParameter("@proid", work.Project_id);
        //    var empid = new SqlParameter("@empid", work.Employee_id);
        //    var hours= new SqlParameter("@hours", work.hours);
        //    var dnum= new SqlParameter("@Dnum", work.Dnum);
       
          
         
        //    d.Database.ExecuteSqlRaw(commandText2, proid,empid,hours,dnum);


        //}

     

    }
}
