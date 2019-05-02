using Dapper.FluentMap;
using Microsoft.Extensions.Configuration;
using MoneyManager.Infrastructure.Persistence.Map;
using System.Data;
using System.Data.SqlClient;

namespace MoneyManager.Infrastructure.Persistence.DataContexts
{
    public class MoneyManagerContext
    {
        private readonly IConfiguration _configuration;

        public MoneyManagerContext(IConfiguration configuration)
        {
            this._configuration = configuration;

            FluentMapper.Initialize(config => {
                config.AddMap(new UserMap());
            });
        }

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(this._configuration.GetConnectionString("MoneyManagerConnection"));
            return connection;
        }

        public bool Commit(IDbTransaction transaction)
        {
            transaction.Commit();
            return true;
        }
    }
}