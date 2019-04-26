using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Api.Domain.ApplicationServices
{
    public interface IApplicationService<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(Guid identifier);
    }
}