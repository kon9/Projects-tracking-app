namespace ProjectTracking.Application.Interfaces;


public interface IUnitOfWork
{
    Task<int> SaveAsync(CancellationToken cancellationToken);
}
