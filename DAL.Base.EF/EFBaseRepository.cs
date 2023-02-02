using Contracts.DAL.Base;
using Contracts.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Base.EF;


public class EFBaseRepository<TEntity> : BaseRepository<TEntity, Guid>, IBaseRepository<TEntity>
    where TEntity : class, IDomainEntityId<Guid>, new()
{
    public EFBaseRepository(DbContext dbContext) : base(dbContext)
    {
    }
}

public class BaseRepository<TEntity, TKey> : IBaseRepository<TKey, TEntity>
    where TEntity : class, IDomainEntityId<TKey>, new()
    where TKey : struct, IEquatable<TKey>
{
    protected DbContext RepoDbContext;
    protected DbSet<TEntity> RepoDbSet;
    
    public BaseRepository(DbContext dbContext)
    {
        RepoDbContext = dbContext;
        RepoDbSet = RepoDbContext.Set<TEntity>();
        if (RepoDbSet == null)
        {
            throw new ArgumentNullException(typeof(TEntity).Name + " was not found as DBSet!");
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsyncBase(bool noTracking = true)
    {
        return await RepoDbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> FirstOrDefault(TKey id, bool noTracking = true)
    {
        return await RepoDbSet.FirstAsync(x => x.Id.Equals(id));
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        return (await RepoDbSet.AddAsync(entity)).Entity;
    }

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        return RepoDbSet.Update(entity).Entity;
    }

    public virtual async Task<TEntity> RemoveAsync(TEntity entity)
    {
        return RepoDbSet.Remove(entity).Entity;
    }

    public virtual async Task<TEntity> RemoveAsync(TKey id)
    {
        var domainEntity = await RepoDbSet.FirstOrDefaultAsync(e => e.Id.Equals(id));
        if (domainEntity == null)
        {
            throw new ArgumentException("Entity to be updated was not found in data source!");
        }

        return RepoDbSet.Remove(domainEntity).Entity;
    }

    public virtual async Task<bool> ExistsAsync(TKey id)
    {
        return await RepoDbSet.AnyAsync(x => x.Id.Equals(id));
    }
}
