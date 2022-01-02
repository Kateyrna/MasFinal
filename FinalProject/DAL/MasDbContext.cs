using FinalProject.Models;
using System.Data.Entity;

namespace FinalProject.DAL
{
    public class MasDbContext : DbContext
    {
        // Your context has been configured to use a 'MasDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinalProject.DAL.MasDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MasDbContext' 
        // connection string in the application configuration file.
        public MasDbContext()
            : base("name=MasDbContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        internal virtual DbSet<Person> Person { get; set; }
        internal virtual DbSet<Employee> Employee { get; set; }
        internal virtual DbSet<Doctor> Doctor { get; set; }
        internal virtual DbSet<Receptionist> Receptionist { get; set; }
        internal virtual DbSet<Patient> Patient { get; set; }
        internal virtual DbSet<Account> Account { get; set; }
        internal virtual DbSet<Login> Login { get; set; }
        internal virtual DbSet<Appointment> Appointment { get; set; }
        internal virtual DbSet<Visit> Visit { get; set; }
        internal virtual DbSet<Prescription> Prescription { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasRequired(s => s.Account)
                .WithRequiredPrincipal(d => d.Login);

            modelBuilder.Entity<Appointment>()
                .HasRequired(s => s.Visit)
                .WithRequiredPrincipal(v => v.Appointment);

            modelBuilder.Entity<Account>()
                .HasRequired(s => s.Employee)
                .WithRequiredPrincipal(e => e.Account);

            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}