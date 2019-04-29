using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IApplicationService<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : IEntity
    {
    }
}