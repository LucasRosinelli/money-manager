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
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork, new RepositoryOptions(
                tableName: "Expenses",
                querySelect: "SELECT E.[Id], E.[Identifier], E.[AccountId], E.[Description], E.[Date], E.[Value], E.[CreatedOn], E.[LastUpdatedOn], E.[Status] FROM [Expenses] E"))
        {
        }

        public override async Task<IEntity> GetByIdAsync(long id, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE E.[Id] = @Id", new { Id = id }, transaction: transaction);
        }

        public async Task<IEntity> GetByIdentifierAsync(Guid identifier, IDbTransaction transaction = null)
        {
            return await this.UnitOfWork.GetConnection().QuerySingleOrDefaultAsync<User>($"{this.Options.QuerySelect} WHERE E.[Identifier] = @Identifier", new { Identifier = identifier }, transaction: transaction);
        }
    }
}