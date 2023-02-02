using Contracts.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Base
{
    public abstract class DomainEntityId : DomainEntityId<Guid>, IDomainEntityId
    {
    }

    public abstract class DomainEntityId<TKey> : IDomainEntityId<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; } = default!;
    }
}
