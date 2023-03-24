using Microsoft.EntityFrameworkCore;
using ProjectTracking.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectTracking.Data.Repository;


public abstract class BaseRepo<T> : IRepo<T> where T : class, IIdentifiable, new()
{
    public ProjectsDbContext Context { get; init; }
    protected DbSet<T> Table;

    public BaseRepo(ProjectsDbContext context)
    {
        Context = context;
    }

    public async Task<Guid> AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        return entity.Id;
    }

    public async Task<Guid> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await Table.AddAsync(entity, cancellationToken);
        return entity.Id;
    }

    public async Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);

        var result = new List<Guid>(entities.Select(e => e.Id));
        return result;
    }

    public async Task<IEnumerable<Guid>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken)
    {
        await Table.AddRangeAsync(entities, cancellationToken);

        var result = new List<Guid>(entities.Select(e => e.Id));
        return result;
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetOneAsync(id);

        if (entity != null)
        {
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }

    public async Task DeleteRangeAsync(IEnumerable<Guid> ids)
    {
        foreach (var id in ids)
        {
            await DeleteAsync(id);
        }
    }

    public virtual async Task<T> GetOneAsync(Guid id)
    {
        return await Task.Run(() => Table.FirstOrDefault(entity => entity.Id == id));
    }

    public virtual async Task<T> GetOneAsync(Guid id, CancellationToken cancellationToken)
    {
        return Table.FirstOrDefault(entity => entity.Id == id); // Todo Task.run, cancellation token, ambiguous invocation
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        return await Table.ToListAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await Table.ToListAsync(cancellationToken);
    }

    public virtual Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
    {
        return Table.Where(predicate).ToListAsync();
    }

    public virtual Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return Table.Where(predicate).ToListAsync(cancellationToken);
    }

    public virtual Task<T> FindUniqueAsync(Expression<Func<T, bool>> predicate)
    {
        return Table.FirstOrDefaultAsync(predicate);
    }

    public virtual Task<T> FindUniqueAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return Table.FirstOrDefaultAsync(predicate, cancellationToken);
    }
}

