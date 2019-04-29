using MoneyManager.Domain.Contracts.Entities;
using System;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.Repositories
{
    public interface IRepositoryExtended<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<IEntity> GetByIdentifier(Guid identifier);
    }
}