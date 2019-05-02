using MoneyManager.Domain.Contracts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<bool> CommitAsync();
        Task<IEntity> CreateAsync(TEntity entity);
        Task<IEntity> UpdateAsync(TEntity entity);
        Task<IEntity> GetByIdAsync(long id);
        Task<IEnumerable<IEntity>> GetAsync();
        Task<IEnumerable<IEntity>> GetAsync(int skip, int take);
    }
}