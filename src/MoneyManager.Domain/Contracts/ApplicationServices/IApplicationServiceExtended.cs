using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IApplicationServiceExtended<TRepository, TEntity>
        where TRepository : IRepositoryExtended<TEntity>
        where TEntity : IEntity
    {
    }
}