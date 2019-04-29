using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Specs;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public UserRepository(MoneyManagerDbContext context)
            : base(context)
        {
        }

        public async Task<IEntity> Create(User entity)
        {
            await this.Context.Users
                .AddAsync(entity);
            return entity;
        }

        public async Task<IEntity> Update(User entity)
        {
            this.Context.Entry<User>(entity).State = EntityState.Modified;
            return entity;
        }

        public async Task<IEntity> GetById(long id)
        {
            return await this.Context.Users
                .Where(UserSpecs.GetById(id))
                .SingleOrDefaultAsync();
        }

        public async Task<IEntity> GetByIdentifier(Guid identifier)
        {
            return await this.Context.Users
                .Where(UserSpecs.GetByIdentifier(identifier))
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<IEntity>> Get()
        {
            return await this.Context.Users
                .ToArrayAsync();
        }

        public async Task<IEnumerable<IEntity>> Get(int skip, int take)
        {
            return await this.Context.Users
                .Skip(skip)
                .Take(take)
                .ToArrayAsync();
        }
    }
}