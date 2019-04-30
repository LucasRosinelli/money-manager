using MoneyManager.Domain.Commands.UserCommands;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.UserDataTransferObject;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IUserApplicationService : IApplicationServiceExtended<IUserRepository, User>
    {
        Task<UserDetailDataTransferObject> Register(RegisterCommand command);
        Task<UserDetailDataTransferObject> ChangeAuthInfo(ChangeAuthInfoCommand command);
        Task<UserDetailDataTransferObject> ChangeBasicInfo(ChangeBasicInfoCommand command);
        Task<UserDetailDataTransferObject> GetByIdentifier(Guid identifier);
        Task<IEnumerable<UserDetailDataTransferObject>> Get();
        Task<IEnumerable<UserDetailDataTransferObject>> Get(int skip, int take);
    }
}