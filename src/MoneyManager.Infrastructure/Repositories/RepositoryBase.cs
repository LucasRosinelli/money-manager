using Dapper;
using Dapper.Contrib.Extensions;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected MoneyManagerContext Context { get; private set; }
        protected RepositoryOptions Options { get; private set; }

        public RepositoryBase(MoneyManagerContext context, RepositoryOptions options)
        {
            this.Context = context;
            this.Options = options;
        }

        public virtual async Task<bool> CommitAsync()
        {
            return true;
        }

        public virtual async Task<IEntity> CreateAsync(TEntity entity)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                var id = await connection.InsertAsync<TEntity>(entity);
                return entity;
            }
        }

        public virtual async Task<IEntity> UpdateAsync(TEntity entity)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                var id = await connection.UpdateAsync<TEntity>(entity);
                return entity;
            }
        }

        public virtual async Task<IEnumerable<IEntity>> GetAsync()
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                return await connection.QueryAsync<TEntity>(this.Options.QuerySelect);
            }
        }

        public virtual async Task<IEnumerable<IEntity>> GetAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public abstract Task<IEntity> GetByIdAsync(long id);
    }
}