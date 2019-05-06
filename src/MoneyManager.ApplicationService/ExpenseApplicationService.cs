using MoneyManager.Domain.Commands.EntryCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.ExpenseDataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.ApplicationService
{
    public class ExpenseApplicationService : ApplicationServiceBase<IExpenseRepository, Expense>, IExpenseApplicationService
    {
        private readonly IAccountRepository _accountRepository;

        public ExpenseApplicationService(IUnitOfWork unitOfWork, IExpenseRepository repository, IAccountRepository accountRepository)
            : base(unitOfWork, repository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<ExpenseDetailDataTransferObject> RegisterAsync(RegisterCommand command)
        {
            var account = await this._accountRepository.GetByIdentifierAsync(command.Account);

            if (account != null)
            {
                var expense = new Expense(account.Id, command.Description, command.Date, command.Value);

                if (expense.Register())
                {
                    using (var transaction = this.UnitOfWork.CreateTransaction())
                    {
                        expense = await this.Repository.CreateAsync(expense, transaction) as Expense;
                        if (this.UnitOfWork.Commit(transaction))
                        {
                            return new ExpenseDetailDataTransferObject(expense);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<ExpenseDetailDataTransferObject> GetByIdentifierAsync(Guid account, Guid identifier)
        {
            if (await this.Repository.GetByIdentifierAsync(identifier) is Expense expense)
            {
                return new ExpenseDetailDataTransferObject(expense);
            }

            return null;
        }

        public async Task<IEnumerable<ExpenseDetailDataTransferObject>> GetAsync(Guid account)
        {
            var expenses = await this.Repository.GetAsync();

            var resultExpenses = new HashSet<ExpenseDetailDataTransferObject>();
            foreach (var expense in expenses)
            {
                resultExpenses.Add(new ExpenseDetailDataTransferObject(expense as Expense));
            }

            return resultExpenses;
        }
    }
}