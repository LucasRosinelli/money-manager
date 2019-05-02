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
        protected string TableName { get; private set; }

        public RepositoryBase(MoneyManagerContext context, string tableName)
        {
            this.Context = context;
            this.TableName = tableName;
        }

        public virtual async Task<bool> Commit()
        {
            return true;
        }

        public virtual async Task<IEntity> Create(TEntity entity)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                var id = await connection.InsertAsync<TEntity>(entity);
                return entity;
            }
        }

        public virtual async Task<IEntity> Update(TEntity entity)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                var id = await connection.UpdateAsync<TEntity>(entity);
                return entity;
            }
        }

        public virtual async Task<IEnumerable<IEntity>> Get()
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                return await connection.QueryAsync<TEntity>($"SELECT * FROM {this.TableName}");
            }
        }

        public virtual async Task<IEnumerable<IEntity>> Get(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public abstract Task<IEntity> GetById(long id);
    }
}