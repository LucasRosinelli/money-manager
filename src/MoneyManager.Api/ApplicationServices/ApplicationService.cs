using MoneyManager.Api.Infrastructure.Persistence.DataContexts;

namespace MoneyManager.Api.ApplicationServices
{
    public abstract class ApplicationService
    {
        public MoneyManagerDbContext Context { get; private set; }

        public ApplicationService(MoneyManagerDbContext context)
        {
            this.Context = context;
        }
    }
}