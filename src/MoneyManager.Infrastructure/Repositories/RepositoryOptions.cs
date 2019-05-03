namespace MoneyManager.Infrastructure.Repositories
{
    public class RepositoryOptions
    {
        public string TableName { get; private set; }
        public string QuerySelect { get; private set; }
        public string QueryInsert { get; private set; }
        public string QueryUpdate { get; private set; }

        public RepositoryOptions(string tableName, string querySelect, string queryInsert = null, string queryUpdate = null)
        {
            this.TableName = tableName;
            this.QuerySelect = querySelect;
            this.QueryInsert = queryInsert;
            this.QueryUpdate = queryUpdate;
        }
    }
}