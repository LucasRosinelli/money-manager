using MoneyManager.Domain.Commands.EntryCommands;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.ExpenseDataTransferObjects;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IExpenseApplicationService : IApplicationServiceExtended<IExpenseRepository, Expense>
    {
        Task<ExpenseDetailDataTransferObject> RegisterAsync(RegisterCommand command);
        Task<ExpenseDetailDataTransferObject> GetByIdentifierAsync(Guid account, Guid identifier);
        Task<IEnumerable<ExpenseDetailDataTransferObject>> GetAsync(Guid account);
    }
}