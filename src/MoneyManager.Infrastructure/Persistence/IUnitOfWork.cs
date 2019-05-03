using MoneyManager.Infrastructure.Persistence.DataContexts;
using System;
using System.Data;

namespace MoneyManager.Infrastructure.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        MoneyManagerContext Context { get; }

        void OpenConnection();
        IDbConnection GetConnection();
        IDbTransaction CreateTransaction();
        IDbTransaction CreateTransaction(IsolationLevel isolationLevel);
        bool Commit(IDbTransaction transaction);
        void Rollback(IDbTransaction transaction);
    }
}