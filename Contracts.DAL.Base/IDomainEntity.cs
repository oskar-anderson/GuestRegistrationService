using Contracts.Domain;

namespace Contracts.DAL.Base;

public interface IDomainEntity : IDomainEntity<Guid>
{
    
}

public interface IDomainEntity<TKey> : IDomainEntityMetadata
{
    public TKey Id { get; set; }
}