using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication5.DAL.Entity;
using WebApplication5.DAL.Extend;

namespace WebApplication5.DAL.Database
{
   public class DataContext:IdentityDbContext<ApplicationUser>
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source = DESKTOP-F7S9FSJ; Initial Catalog = Union; Integrated Security = True; Pooling = False");

        //}
        //connection string enhancement
        public DataContext(DbContextOptions<DataContext>opt):base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //make composite primary key for works for
            builder.Entity<Works_For>().HasKey(a => new { a.Employee_id, a.Project_id });

            builder.Entity<IdentityUserLogin<string>>().HasKey(a => a.ProviderKey);
            //The entity type 'IdentityUserRole<string>' requires a primary key to be defined 
            builder.Entity<IdentityUserRole<string>>().HasNoKey();
            builder.Entity<IdentityUserToken<string>>().HasNoKey();
        }
        //db set class help to apply operation on entities
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Works_For> works { get; set; }
    }
}
