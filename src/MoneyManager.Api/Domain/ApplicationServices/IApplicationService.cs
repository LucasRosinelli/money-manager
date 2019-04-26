using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Api.Domain.ApplicationServices
{
    public interface IApplicationService<TEntity, TKey>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid identifier);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TKey key, TEntity entity);
    }
}