using MoneyManager.Domain.Commands.UserCommands;
using MoneyManager.Domain.Contracts.ApplicationServices;
using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.DataTransferObjects.UserDataTransferObjects;
using MoneyManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoneyManager.ApplicationService
{
    public class UserApplicationService : ApplicationServiceBase<IUserRepository, User>, IUserApplicationService
    {
        public UserApplicationService(IUserRepository repository)
            : base(repository)
        {
        }

        public async Task<UserDetailDataTransferObject> RegisterAsync(RegisterCommand command)
        {
            var user = new User(command.Login, command.Password, command.FullName);

            if (user.Register())
            {
                user = await this.Repository.CreateAsync(user) as User;
                if (await this.Repository.CommitAsync())
                {
                    return new UserDetailDataTransferObject(user);
                }
            }

            return null;
        }

        public async Task<UserDetailDataTransferObject> ChangeAuthInfoAsync(ChangeAuthInfoCommand command)
        {
            if (await this.Repository.GetByIdentifierAsync(command.Identifier) is User user && user.ChangeAuthInfo(command.Login, command.Password))
            {
                user = await this.Repository.UpdateAsync(user) as User;
                if (await this.Repository.CommitAsync())
                {
                    return new UserDetailDataTransferObject(user);
                }
            }

            return null;
        }

        public async Task<UserDetailDataTransferObject> ChangeBasicInfoAsync(ChangeBasicInfoCommand command)
        {
            if (await this.Repository.GetByIdentifierAsync(command.Identifier) is User user && user.ChangeBasicInfo(command.FullName))
            {
                user = await this.Repository.UpdateAsync(user) as User;
                if (await this.Repository.CommitAsync())
                {
                    return new UserDetailDataTransferObject(user);
                }
            }

            return null;
        }

        public async Task<UserDetailDataTransferObject> GetByIdentifierAsync(Guid identifier)
        {
            if (await this.Repository.GetByIdentifierAsync(identifier) is User user)
            {
                return new UserDetailDataTransferObject(user);
            }

            return null;
        }

        public async Task<IEnumerable<UserDetailDataTransferObject>> GetAsync()
        {
            var users = await this.Repository.GetAsync();

            var resultUsers = new HashSet<UserDetailDataTransferObject>();
            foreach (var user in users)
            {
                resultUsers.Add(new UserDetailDataTransferObject(user as User));
            }

            return resultUsers;
        }

        public async Task<IEnumerable<UserDetailDataTransferObject>> GetAsync(int skip, int take)
        {
            var users = await this.Repository.GetAsync(skip, take);

            var resultUsers = new HashSet<UserDetailDataTransferObject>();
            foreach (var user in users)
            {
                resultUsers.Add(new UserDetailDataTransferObject(user as User));
            }

            return resultUsers;
        }
    }
}