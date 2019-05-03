using MoneyManager.Infrastructure.Persistence.DataContexts;
using System.Data;
using System.Data.SqlClient;

namespace MoneyManager.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;

        public MoneyManagerContext Context { get; private set; }

        public UnitOfWork(MoneyManagerContext context)
        {
            this.Context = context;
            this._connection = new SqlConnection(this.Context.ConnectionString);
        }

        public void OpenConnection()
        {
            if (this._connection.State != ConnectionState.Open)
            {
                this._connection.Open();
            }
        }

        public IDbConnection GetConnection()
        {
            this.OpenConnection();
            return this._connection;
        }

        public IDbTransaction CreateTransaction()
        {
            return this.GetConnection().BeginTransaction();
        }

        public IDbTransaction CreateTransaction(IsolationLevel isolationLevel)
        {
            return this.GetConnection().BeginTransaction(isolationLevel);
        }

        public bool Commit(IDbTransaction transaction)
        {
            var hasNotifications = false;

            if (!hasNotifications)
            {
                transaction?.Commit();
                return true;
            }

            transaction?.Rollback();
            return false;
        }

        public void Rollback(IDbTransaction transaction)
        {
            transaction?.Rollback();
        }

        public void Dispose()
        {
            this.Context = null;
            this._connection.Dispose();
        }
    }
}