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
            : base(context, new RepositoryOptions(
                tableName: "Users",
                querySelect: "SELECT U.[Id], U.[Identifier], U.[Login], U.[Password], U.[FullName], U.[CreatedOn], U.[LastUpdatedOn], U.[Status] FROM [Users] U"))
        {
        }

        public override async Task<IEntity> GetByIdAsync(long id)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE U.[Id] = @Id", new { Id = id });
            }
        }

        public async Task<IEntity> GetByIdentifierAsync(Guid identifier)
        {
            using (var connection = this.Context.CreateConnection())
            {
                connection.Open();
                return await connection.QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE U.[Identifier] = @Identifier", new { Identifier = identifier });
            }
        }
    }
}