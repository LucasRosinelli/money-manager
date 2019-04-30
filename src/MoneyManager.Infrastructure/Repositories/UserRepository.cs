using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Specs;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MoneyManagerDbContext context)
            : base(context)
        {
        }

        public override async Task<IEntity> GetById(long id)
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
    }
}