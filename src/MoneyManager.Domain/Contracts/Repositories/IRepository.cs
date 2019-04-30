using MoneyManager.Domain.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<bool> Commit();
        Task<IEntity> Create(TEntity entity);
        Task<IEntity> Update(TEntity entity);
        Task<IEntity> GetById(long id);
        Task<IEnumerable<IEntity>> Get();
        Task<IEnumerable<IEntity>> Get(int skip, int take);
    }
}