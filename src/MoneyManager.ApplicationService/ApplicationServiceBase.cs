using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;

namespace MoneyManager.ApplicationService
{
    public abstract class ApplicationServiceBase<TRepository, TEntity> : IApplicationService<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public TRepository Repository { get; private set; }

        public ApplicationServiceBase(TRepository repository)
        {
            this.Repository = repository;
        }
    }
}