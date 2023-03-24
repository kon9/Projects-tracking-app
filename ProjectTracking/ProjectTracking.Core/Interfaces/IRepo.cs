using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Core.Interfaces;

public interface IRepo<T>
{
    Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    Task<T> GetOneAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync( CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id);
    Task DeleteRangeAsync(IEnumerable<Guid> ids);
    Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> FindUniqueAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

}