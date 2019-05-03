using MoneyManager.Domain.Commands.UserCommands;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.UserDataTransferObjects;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IUserApplicationService : IApplicationServiceExtended<IUserRepository, User>
    {
        Task<UserDetailDataTransferObject> RegisterAsync(RegisterCommand command);
        Task<UserDetailDataTransferObject> ChangeAuthInfoAsync(ChangeAuthInfoCommand command);
        Task<UserDetailDataTransferObject> ChangeBasicInfoAsync(ChangeBasicInfoCommand command);
        Task<UserDetailDataTransferObject> GetByIdentifierAsync(Guid identifier);
        Task<IEnumerable<UserDetailDataTransferObject>> GetAsync();
        Task<IEnumerable<UserDetailDataTransferObject>> GetAsync(int skip, int take);
    }
}