using Dapper;
using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.Entities;
using MoneyManager.Infrastructure.Persistence;
using System;
using System.Data;
using System.Threading.Tasks;

namespace MoneyManager.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, new RepositoryOptions(
                tableName: "Users",
                querySelect: "SELECT U.[Id], U.[Identifier], U.[Login], U.[Password], U.[FullName], U.[Balance], U.[CreatedOn], U.[LastUpdatedOn], U.[Status] FROM [Users] U"))
        {
        }

        public override async Task<IEntity> GetByIdAsync(long id, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE U.[Id] = @Id", new { Id = id }, transaction: transaction);
        }

        public async Task<IEntity> GetByIdentifierAsync(Guid identifier, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE U.[Identifier] = @Identifier", new { Identifier = identifier }, transaction: transaction);
        }
    }
}