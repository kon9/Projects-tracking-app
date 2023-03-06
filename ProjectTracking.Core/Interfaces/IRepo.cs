using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Interfaces;

public interface IRepo<T>
{
    Task<Guid> AddAsync(T entity);
    Task<Guid> AddAsync(T entity, CancellationToken cancellationToken);

    Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities);
    Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken);

    Task<T> GetOneAsync(Guid id);
    Task<T> GetOneAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    Task DeleteAsync(Guid id);
    Task DeleteRangeAsync(IEnumerable<Guid> ids);

    Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    Task<T> FindUniqueAsync(Expression<Func<T, bool>> predicate);
    Task<T> FindUniqueAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

    Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);
    Task<bool> ExistAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);


}