using Microsoft.EntityFrameworkCore;
using PIMTool.Core.Domain.Entities;

namespace PIMTool.Database
{
    public class PimContext : DbContext
    {
        public PimContext(DbContextOptions options) : base(options)
        {
        }
        // TODO: Define your models
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Project>()
                .Property(p => p.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .ValueGeneratedNever();
           
            modelBuilder.Entity<Project>()
              .HasOne<Group>(p => p.Group)
              .WithMany(g => g.Projects)
              .HasForeignKey(p => p.GroupId);

            modelBuilder.Entity<Group>()
            .HasOne(g => g.GroupLeader)
            .WithOne(e => e.Group)
            .HasForeignKey<Group>(g => g.GroupLeaderId);
            // TẠM THỜI SAI VÌ KHÔNG SỬA ĐƯỢC


            modelBuilder.Entity<ProjectEmployee>()
             .HasKey(pe => new { pe.ProjectId, pe.EmployeeId });


            modelBuilder.Entity<ProjectEmployee>()
              .HasOne(pe => pe.Project)
              .WithMany(p => p.ProjectEmployees)
              .HasForeignKey(pe => pe.ProjectId)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ProjectEmployee>()
              .HasOne(pe => pe.Employee)
              .WithMany(e => e.ProjectEmployees)
              .HasForeignKey(pe => pe.EmployeeId)
              .OnDelete(DeleteBehavior.Restrict);

        }


    }
}