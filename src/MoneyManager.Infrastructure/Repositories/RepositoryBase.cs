using MoneyManager.Infrastructure.Persistence.DataContexts;

namespace MoneyManager.Infrastructure.Repositories
{
    public class RepositoryBase
    {
        public MoneyManagerDbContext Context { get; private set; }

        public RepositoryBase(MoneyManagerDbContext context)
        {
            this.Context = context;
        }
    }
}