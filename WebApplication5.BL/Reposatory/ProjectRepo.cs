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
    public class ProjectRepo : IProject
    {
        readonly private DataContext d;
        public ProjectRepo(DataContext d)
        {
            this.d = d;

        }
        //get list  of project that apply filter
        public IEnumerable<Project> getFilter(Func<Project, bool> filter = null)
        {
            if (filter == null)
            {
                var data = d.Projects.Select(a => a);
                return data;
            }
            else
            {
                var data = d.Projects.Include("Department").Where(filter);
                return data;
            }
        }
        //this method create project and append it to database
        public void create(Project pro)
        {
            d.Projects.Add(pro);
            d.SaveChanges();
        }
        //this method delete project from database
        public void delete(Project pro)
        {
            var data = d.Projects.Find(pro.id);
            d.Projects.Remove(data);
            d.SaveChanges();
        }
        //this method get all project from database
        public IEnumerable<Project> get()
        {
            var data = d.Projects.Include("Department").Select(a => a);
            return data;
        }
        //this method get project from database based on id
        public Project getbyid(int id)
        {
            var data = d.Projects.Find(id);
            return data;
        }
        //this method update project in database
        //pro contain new values
        public void update(Project pro)
        {
            d.Entry(pro).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            d.SaveChanges();
        }

       
    }
}
