using Dapper.FluentMap;
using Microsoft.Extensions.Configuration;
using MoneyManager.Infrastructure.Persistence.Map;

namespace MoneyManager.Infrastructure.Persistence.DataContexts
{
    public class MoneyManagerContext
    {
        private readonly IConfiguration _configuration;

        internal string ConnectionString { get; private set; }

        public MoneyManagerContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.ConnectionString = this._configuration.GetConnectionString("MoneyManagerConnection");

            FluentMapper.Initialize(config => {
                config.AddMap(new UserMap());
            });
        }
    }
}