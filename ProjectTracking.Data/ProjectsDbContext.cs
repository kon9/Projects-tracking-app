using Microsoft.EntityFrameworkCore;
using ProjectTracking.Application.Interfaces;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Data
{
    public class ProjectsDbContext : DbContext, IProjectsDbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }
}
