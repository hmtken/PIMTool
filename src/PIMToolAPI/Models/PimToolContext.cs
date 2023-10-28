

using Microsoft.EntityFrameworkCore;

namespace PIMToolAPI.Models
{
    public class PimToolContext: DbContext
    {
        public PimToolContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private static string GetConnectionString()
        {
            IConfiguration builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return builder["ConnectionStrings:DefaultConnection"];
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.Entity<Group>()
              .HasOne(g => g.GroupLeader)
              .WithOne(e => e.Group)
              .HasForeignKey<Group>(g => g.GroupLeaderId);

            modelBuilder.Entity<Project>()
              .HasOne(p => p.Group)
              .WithMany(g => g.Projects)
              .HasForeignKey(p => p.GroupId);

            modelBuilder.Entity<ProjectEmployee>()
            .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });

            modelBuilder.Entity<ProjectEmployee>()
              .HasOne(pe => pe.Project)
              .WithMany(p => p.ProjectEmployees)
              .HasForeignKey(pe => pe.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<ProjectEmployee>()
              .HasOne(pe => pe.Employee)
              .WithMany(e => e.ProjectEmployees)
              .HasForeignKey(pe => pe.EmployeeId)
              .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
