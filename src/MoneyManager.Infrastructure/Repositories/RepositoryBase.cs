using Dapper;
using Dapper.Contrib.Extensions;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected IUnitOfWork UnitOfWork { get; private set; }
        protected RepositoryOptions Options { get; private set; }

        public RepositoryBase(IUnitOfWork unitOfWork, RepositoryOptions options)
        {
            this.UnitOfWork = unitOfWork;
            this.Options = options;
        }

        public virtual async Task<IEntity> CreateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            var id = await this.UnitOfWork.GetConnection().InsertAsync<TEntity>(entity, transaction: transaction);
            return entity;
        }

        public virtual async Task<IEntity> UpdateAsync(TEntity entity, IDbTransaction transaction = null)
        {
            var id = await this.UnitOfWork.GetConnection().UpdateAsync<TEntity>(entity, transaction: transaction);
            return entity;
        }

        public virtual async Task<IEnumerable<IEntity>> GetAsync(IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QueryAsync<TEntity>(this.Options.QuerySelect, transaction: transaction);
        }

        public virtual async Task<IEnumerable<IEntity>> GetAsync(int skip, int take, IDbTransaction transaction = null)
        {
            throw new NotImplementedException();
        }

        public abstract Task<IEntity> GetByIdAsync(long id, IDbTransaction transaction = null);
    }
}