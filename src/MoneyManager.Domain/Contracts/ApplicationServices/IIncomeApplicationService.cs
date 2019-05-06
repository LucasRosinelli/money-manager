using MoneyManager.Domain.Commands.EntryCommands;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.IncomeDataTransferObjects;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IIncomeApplicationService : IApplicationServiceExtended<IIncomeRepository, Income>
    {
        Task<IncomeDetailDataTransferObject> RegisterAsync(RegisterCommand command);
        Task<IncomeDetailDataTransferObject> GetByIdentifierAsync(Guid account, Guid identifier);
        Task<IEnumerable<IncomeDetailDataTransferObject>> GetAsync(Guid account);
    }
}