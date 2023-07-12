

namespace WebApplication5.DAL.Database;

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

        builder.Entity<Works_For>().HasKey(a => new { a.EmployeeId, a.ProjectId });


        builder.Entity<Employee>()
      .HasMany(p => p.work)
      .WithOne(t => t.Employee)
      .OnDelete(DeleteBehavior.Restrict);


        builder.Entity<Project>()
     .HasMany(p => p.work)
     .WithOne(t => t.Project)
     .OnDelete(DeleteBehavior.Restrict);

        //The entity type 'IdentityUserRole<string>' requires a primary key to be defined 
        builder.Entity<IdentityUserLogin<string>>().HasKey(a => a.ProviderKey);
        builder.Entity<IdentityUserRole<string>>().HasNoKey();
            builder.Entity<IdentityUserToken<string>>().HasNoKey();
       
     
    }
        //db set class help to apply operation on entities
        public virtual DbSet<Employee> employees { get; set; }
        public virtual DbSet<Department> departments { get; set; }

        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Works_For> works { get; set; }
    
}
