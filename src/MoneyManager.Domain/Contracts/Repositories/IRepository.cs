using MoneyManager.Domain.Contracts.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        Task<IEntity> CreateAsync(TEntity entity, IDbTransaction transaction = null);
        Task<IEntity> UpdateAsync(TEntity entity, IDbTransaction transaction = null);
        Task<IEntity> GetByIdAsync(long id, IDbTransaction transaction = null);
        Task<IEnumerable<IEntity>> GetAsync(IDbTransaction transaction = null);
        Task<IEnumerable<IEntity>> GetAsync(int skip, int take, IDbTransaction transaction = null);
    }
}