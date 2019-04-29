using MoneyManager.Domain.Contracts.Entities;
using System;

namespace MoneyManager.Domain.Contracts.Repositories
{
    public interface IRepositoryExtended<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        IEntity GetByIdentifier(Guid identifier);
    }
}