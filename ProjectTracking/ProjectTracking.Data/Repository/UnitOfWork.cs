using ProjectTracking.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ProjectsDbContext context;

    public UnitOfWork(ProjectsDbContext context) => this.context = context;

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return context.SaveChangesAsync(cancellationToken);
    }
}