


namespace WebApplication5.BL.Reposatory;

    public class WorksRepo : IWorks_For
    {
        readonly private DataContext db;
        public WorksRepo(DataContext db)
        {
            this.db = db;

        }
        //this method get all records from database based on filter from works entity
        public IEnumerable<Works_For> getFilter(Func<Works_For, bool> filter = null)
        {
            if (filter == null)
            {
                var data = db.works.Select(a => a);
                return data;
            }
            else
            {
                var data = db.works.AsSplitQuery().Include("Employee").Include("Project").Where(filter);
                return data;
            }
        }
        //this method add record to works entity in database
        public void create(Works_For work)
        {
           db.works.Add(work);
           db.SaveChanges();
        }

        //this method delete record from works entity in database
        public void delete(Works_For work)
        {
            db.works.Remove(work);
            db.SaveChanges();
        }
        //this method get all records from database 
        public IEnumerable<Works_For> get()
        {
           var data= db.works.Select(a => a).AsNoTracking();
            return data;
        }

    public void deleteEmployee(int id)
    { var data = db.works.Where(a => a.EmployeeId == id);
        db.works.RemoveRange(data);
    }

    public void deleteProject(int id)
    {
        var data = db.works.Where(a => a.ProjectId == id);
        db.works.RemoveRange(data);
    }
}

