using MoneyManager.Domain.Commands.AccountCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.AccountDataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.ApplicationService
{
    public class AccountApplicationService : ApplicationServiceBase<IAccountRepository, Account>, IAccountApplicationService
    {
        private readonly IUserRepository _userRepository;

        public AccountApplicationService(IUnitOfWork unitOfWork, IAccountRepository repository, IUserRepository userRepository)
            : base(unitOfWork, repository)
        {
            this._userRepository = userRepository;
        }

        public async Task<AccountDetailDataTransferObject> RegisterAsync(RegisterCommand command)
        {
            var user = await this._userRepository.GetByIdentifierAsync(command.User);

            if (user != null)
            {
                var account = new Account(user.Id, command.ShortName, command.LongName, command.Color, command.Icon);

                if (account.Register())
                {
                    using (var transaction = this.UnitOfWork.CreateTransaction())
                    {
                        account = await this.Repository.CreateAsync(account, transaction) as Account;
                        if (this.UnitOfWork.Commit(transaction))
                        {
                            return new AccountDetailDataTransferObject(account);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<AccountDetailDataTransferObject> ChangeInfoAsync(ChangeInfoCommand command)
        {
            using (var transaction = this.UnitOfWork.CreateTransaction())
            {
                if (await this.Repository.GetByIdentifierAsync(command.Identifier, transaction) is Account account && account.ChangeInfo(command.ShortName, command.LongName, command.Color, command.Icon))
                {
                    account = await this.Repository.UpdateAsync(account, transaction) as Account;
                    if (this.UnitOfWork.Commit(transaction))
                    {
                        return new AccountDetailDataTransferObject(account);
                    }
                }
            }

            return null;
        }

        public async Task<AccountDetailDataTransferObject> GetByIdentifierAsync(Guid user, Guid identifier)
        {
            if (await this.Repository.GetByIdentifierAsync(identifier) is Account account)
            {
                return new AccountDetailDataTransferObject(account);
            }

            return null;
        }

        public async Task<IEnumerable<AccountDetailDataTransferObject>> GetAsync(Guid user)
        {
            var accounts = await this.Repository.GetAsync();

            var resultAccounts = new HashSet<AccountDetailDataTransferObject>();
            foreach (var account in accounts)
            {
                resultAccounts.Add(new AccountDetailDataTransferObject(account as Account));
            }

            return resultAccounts;
        }
    }
}