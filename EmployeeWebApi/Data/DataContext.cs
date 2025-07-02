using EmployeeWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebApi.Data
{
    public class DataContext :DbContext
    {
        //ctor for constructor

        //DbContextOptions<DataContext> options -  connections strings.dbtimeouts,lazyloading,logging and etc
        public DataContext(DbContextOptions<DataContext> options) :base(options) // pass configuration details about how EF should connect to and interact with your database -? from appsettings.json get connectionsrtings and other props and bind in program.cs to here
                                                                               //DbContextOptions<DataContext>	Holds all config (connection string, provider, etc.)
        {

        }
        /*in Startup.cs or Program.cs:
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("YourConnectionString"));*/

        //db set for entities

        DbSet<Employee> Employees { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Manager> Manager { get; set; }
        DbSet<ProjectManager> ProjectsManager { get; set; }

        DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //customize tables here

            //m-n relationship maintain
            modelBuilder.Entity<ProjectManager>()
                .HasKey(pm => new { pm.ProjectId, pm.ManagerId }); //combined pk

            modelBuilder.Entity<ProjectManager>()
                .HasOne(p => p.Project)
                .WithMany(pm => pm.ProjectManagers)
                .HasForeignKey(p => p.ProjectId);  //mapping to project side

            modelBuilder.Entity<ProjectManager>()
                .HasOne(m => m.Manager)
                .WithMany(pm => pm.ProjectManagers)
                .HasForeignKey(m => m.ManagerId); //mapping to manager side



            //1-m mapping  -- managet employy and employee project
            //manager employee
            modelBuilder.Entity<Employee>()
        .HasOne(e => e.Manager)//employee has 1 manager
        .WithMany(m => m.Employees)//reverse mapping - jpa mappedBy
        .HasForeignKey(e => e.ManagerId)//FK mapping
        .OnDelete(DeleteBehavior.Cascade);

            //employee project
            modelBuilder.Entity<Employee>()
       .HasOne(e => e.Project)//employee has 1 project
       .WithMany(p => p.Employees)//reverse mapping - jpa mappedBy
       .HasForeignKey(e => e.ProjectId)//FK mapping -> no need to specify entity since 1-m but better
       .OnDelete(DeleteBehavior.Cascade);


            //1-1 mapping
            //employee address
            modelBuilder.Entity<Employee>()
    .HasOne(e => e.Adderss)//this ^ employee got 1 adderss
    .WithOne(a => a.Employee)
    .HasForeignKey<Employee>(e=>e.AdderssId)//fk mapping - must define fk entity to avoid confusion
    .OnDelete(DeleteBehavior.Cascade);


            //seeding can be used to init data to db - on startup  like Creating admin users


        }


    }
}
