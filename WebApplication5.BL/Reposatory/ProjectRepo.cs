

namespace WebApplication5.BL.Reposatory;

    public class ProjectRepo : IProject
    {
        readonly private DataContext db;
        public ProjectRepo(DataContext db)
        {
            this.db = db;

        }
        //get list  of project that apply filter
        public IEnumerable<Project> getFilter(Func<Project, bool> filter = null)
        {
            if (filter == null)
            {
                var data = db.Projects.Select(a => a);
                return data;
            }
            else
            {
                var data = db.Projects.Include("Department").Where(filter);
                return data;
            }
        }
        //this method create project and append it to database
        public void create(Project pro)
        {
           db.Projects.Add(pro);
           db.SaveChanges();
        }
        //this method delete project from database
        public void delete(Project pro)
        {
    
            db.Projects.Remove(db.Projects.Find(pro.id));
            db.SaveChanges();
        }
        //this method get all project from database
        public IEnumerable<Project> get()
        {
            var data = db.Projects.Include("Department").Select(a => a);
            return data;
        }
        //this method get project from database based on id
        public Project getbyid(int id)
        {
            var data = db.Projects.Find(id);
            return data;
        }
        //this method update project in database
        //pro contain new values
        public void update(Project pro)
        {
           db.Entry(pro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
           db.SaveChanges();
        }

       
    }

