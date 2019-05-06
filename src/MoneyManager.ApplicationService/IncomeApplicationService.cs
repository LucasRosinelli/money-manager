using MoneyManager.Domain.Commands.EntryCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.IncomeDataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.ApplicationService
{
    public class IncomeApplicationService : ApplicationServiceBase<IIncomeRepository, Income>, IIncomeApplicationService
    {
        private readonly IAccountRepository _accountRepository;

        public IncomeApplicationService(IUnitOfWork unitOfWork, IIncomeRepository repository, IAccountRepository accountRepository)
            : base(unitOfWork, repository)
        {
            this._accountRepository = accountRepository;
        }

        public async Task<IncomeDetailDataTransferObject> RegisterAsync(RegisterCommand command)
        {
            var account = await this._accountRepository.GetByIdentifierAsync(command.Account);

            if (account != null)
            {
                var income = new Income(account.Id, command.Description, command.Date, command.Value);

                if (income.Register())
                {
                    using (var transaction = this.UnitOfWork.CreateTransaction())
                    {
                        income = await this.Repository.CreateAsync(income, transaction) as Income;
                        if (this.UnitOfWork.Commit(transaction))
                        {
                            return new IncomeDetailDataTransferObject(income);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<IncomeDetailDataTransferObject> GetByIdentifierAsync(Guid account, Guid identifier)
        {
            if (await this.Repository.GetByIdentifierAsync(identifier) is Income income)
            {
                return new IncomeDetailDataTransferObject(income);
            }

            return null;
        }

        public async Task<IEnumerable<IncomeDetailDataTransferObject>> GetAsync(Guid account)
        {
            var incomes = await this.Repository.GetAsync();

            var resultIncomes = new HashSet<IncomeDetailDataTransferObject>();
            foreach (var income in incomes)
            {
                resultIncomes.Add(new IncomeDetailDataTransferObject(income as Income));
            }

            return resultIncomes;
        }
    }
}