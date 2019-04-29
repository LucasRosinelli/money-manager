using MoneyManager.Domain.Commands.UserCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.UserDataTransferObject;
using MoneyManager.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace MoneyManager.ApplicationService
{
    public class UserApplicationService : ApplicationServiceBase<IUserRepository, User>, IUserApplicationService
    {
        public UserApplicationService(IUserRepository repository)
            : base(repository)
        {
        }

        public async Task<UserDetailDataTransferObject> Register(RegisterCommand command)
        {
            var user = new User(command.Login, command.Password, command.FullName);

            if (user.Register())
            {
                user = await this.Repository.Create(user) as User;
                if (await this.Repository.Commit())
                {
                    return new UserDetailDataTransferObject(user);
                }
            }

            return null;
        }

        public async Task<UserDetailDataTransferObject> ChangeAuthInfo(ChangeAuthInfoCommand command)
        {
            if (await this.Repository.GetByIdentifier(command.Identifier) is User user && user.ChangeAuthInfo(command.Login, command.Password))
            {
                user = await this.Repository.Update(user) as User;
                if (await this.Repository.Commit())
                {
                    return new UserDetailDataTransferObject(user);
                }
            }

            return null;
        }

        public async Task<UserDetailDataTransferObject> ChangeBasicInfo(ChangeBasicInfoCommand command)
        {
            if (await this.Repository.GetByIdentifier(command.Identifier) is User user && user.ChangeBasicInfo(command.FullName))
            {
                user = await this.Repository.Update(user) as User;
                if (await this.Repository.Commit())
                {
                    return new UserDetailDataTransferObject(user);
                }
            }

            return null;
        }

        public async Task<UserDetailDataTransferObject> GetByIdentifier(Guid identifier)
        {
            return new UserDetailDataTransferObject(await this.Repository.GetByIdentifier(identifier) as User);
        }
    }
}