using MoneyManager.Domain.Contracts.Entities;
using System;
using System.Collections.Generic;

namespace MoneyManager.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        IEntity Create(TEntity entity);
        IEntity Update(TEntity entity);
        IEntity GetById(long id);
        IEntity GetById(Guid identifier);
        IEnumerable<IEntity> Get();
    }
}