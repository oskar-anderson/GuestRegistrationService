using Contracts.Domain;

namespace Contracts.DAL.Base;

public interface IBaseRepository<TEntity> : IBaseRepository<Guid, TEntity>
    where TEntity : class, IDomainEntityId<Guid>, new()
{
    
}

public interface IBaseRepository<in TKey, TEntity>
    where TKey : struct, IEquatable<TKey>
    where TEntity : class, IDomainEntityId<TKey>, new()
{
    Task<IEnumerable<TEntity>> GetAllAsyncBase(bool noTracking = true);
    Task<TEntity?> FirstOrDefault(TKey id, bool noTracking = true);
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task<TEntity> RemoveAsync(TEntity entity);
    Task<TEntity> RemoveAsync(TKey id);
    Task<bool> ExistsAsync(TKey id);
}