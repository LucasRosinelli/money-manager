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
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, new RepositoryOptions(
                tableName: "Accounts",
                querySelect: "SELECT A.[Id], A.[Identifier], A.[UserId], A.[ShortName], A.[LongName], A.[Color], A.[Icon], A.[CreatedOn], A.[LastUpdatedOn], A.[Status] FROM [Accounts] A"))
        {
        }

        public override async Task<IEntity> GetByIdAsync(long id, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<Account>($"{this.Options.QuerySelect} WHERE A.[Id] = @Id", new { Id = id }, transaction: transaction);
        }

        public async Task<IEntity> GetByIdentifierAsync(Guid identifier, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<Account>($"{this.Options.QuerySelect} WHERE A.[Identifier] = @Identifier", new { Identifier = identifier }, transaction: transaction);
        }
    }
}