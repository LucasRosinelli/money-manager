using System;

namespace MoneyManager.Domain.Contracts.Entities
{
    public interface IEntityExtended<TState> : IEntity
    {
        Guid Identifier { get; }
        DateTimeOffset CreatedOn { get; }
        DateTimeOffset? LastUpdatedOn { get; }
        TState Status { get; }
    }
}