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
    public class IncomeRepository : RepositoryBase<Income>, IIncomeRepository
    {
        public IncomeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, new RepositoryOptions(
                tableName: "Incomes",
                querySelect: "SELECT I.[Id], I.[Identifier], I.[AccountId], I.[Description], I.[Date], I.[Value], I.[CreatedOn], I.[LastUpdatedOn], I.[Status] FROM [Incomes] I"))
        {
        }

        public override async Task<IEntity> GetByIdAsync(long id, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE I.[Id] = @Id", new { Id = id }, transaction: transaction);
        }

        public async Task<IEntity> GetByIdentifierAsync(Guid identifier, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE I.[Identifier] = @Identifier", new { Identifier = identifier }, transaction: transaction);
        }
    }
}