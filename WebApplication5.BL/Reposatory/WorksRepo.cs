﻿


namespace WebApplication5.BL.Reposatory;

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

    public void deleteEmployee(int id)
    { var data = d.works.Where(a => a.employeeId == id);
        d.works.RemoveRange(data);
    }

    public void deleteProject(int id)
    {
        var data = d.works.Where(a => a.projectId == id);
        d.works.RemoveRange(data);
    }
}

