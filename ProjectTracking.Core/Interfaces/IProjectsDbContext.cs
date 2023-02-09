using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Interfaces
{
    public interface IProjectsDbContext
    {
        DbSet<Project> Projects { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<ProjectTask> ProjectTasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
