using MoneyManager.Api.Domain.Entities;
using System;

namespace MoneyManager.Api.Domain.ApplicationServices
{
    public interface IUserApplicationService : IApplicationService<User, Guid>
    {
    }
}