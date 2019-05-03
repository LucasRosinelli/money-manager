using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Infrastructure.Persistence;

namespace MoneyManager.ApplicationService
{
    public abstract class ApplicationServiceBase<TRepository, TEntity> : IApplicationService<TRepository, TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public IUnitOfWork UnitOfWork { get; private set; }
        public TRepository Repository { get; private set; }

        public ApplicationServiceBase(IUnitOfWork unitOfWork, TRepository repository)
        {
            this.UnitOfWork = unitOfWork;
            this.Repository = repository;
        }
    }
}