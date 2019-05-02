using Dapper;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using System;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MoneyManagerContext context)
            : base(context, "Users")
        {
        }

        public override async Task<IEntity> GetById(long id)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM " + this.TableName + " U WHERE U.[Id] = @Id", new { Id = id });
            }
        }

        public async Task<IEntity> GetByIdentifier(Guid identifier)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM " + this.TableName + " U WHERE U.[Identifier] = @Identifier", new { Identifier = identifier });
            }
        }
    }
}