using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Models;

namespace ProjectTracking.Data
{
    public class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options)
    : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
    }
}
