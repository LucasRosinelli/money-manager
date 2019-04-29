using MoneyManager.Domain.Contracts.Repositories;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Domain.Contracts.ApplicationServices
{
    public interface IUserApplicationService : IApplicationServiceExtended<IUserRepository, User>
    {
    }
}