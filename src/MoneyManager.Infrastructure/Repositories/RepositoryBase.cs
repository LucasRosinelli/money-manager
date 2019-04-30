using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        public MoneyManagerDbContext Context { get; private set; }

        public RepositoryBase(MoneyManagerDbContext context)
        {
            this.Context = context;
        }

        public virtual async Task<bool> Commit()
        {
            var result = await this.Context.SaveChangesAsync();
            return result > 0;

        }

        public virtual async Task<IEntity> Create(TEntity entity)
        {
            await this.Context
                .AddAsync<TEntity>(entity);
            return entity;
        }

        public virtual async Task<IEntity> Update(TEntity entity)
        {
            this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual async Task<IEnumerable<IEntity>> Get()
        {
            return await this.Context.Set<TEntity>()
                .ToArrayAsync();
        }

        public virtual async Task<IEnumerable<IEntity>> Get(int skip, int take)
        {
            return await this.Context.Set<TEntity>()
                .Skip(skip)
                .Take(take)
                .ToArrayAsync();
        }

        public abstract Task<IEntity> GetById(long id);
    }
}