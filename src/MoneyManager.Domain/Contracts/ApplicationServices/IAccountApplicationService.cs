using MoneyManager.Domain.Commands.AccountCommands;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.AccountDataTransferObjects;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IAccountApplicationService : IApplicationServiceExtended<IAccountRepository, Account>
    {
        Task<AccountDetailDataTransferObject> RegisterAsync(RegisterCommand command);
        Task<AccountDetailDataTransferObject> ChangeInfoAsync(ChangeInfoCommand command);
        Task<AccountDetailDataTransferObject> GetByIdentifierAsync(Guid user, Guid identifier);
        Task<IEnumerable<AccountDetailDataTransferObject>> GetAsync(Guid user);
    }
}