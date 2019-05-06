using Dapper.FluentMap.Dommel.Mapping;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infrastructure.Persistence.Map
{
    public class IncomeMap : DommelEntityMap<Income>
    {
        public IncomeMap()
        {
            this.ToTable("Incomes");

            //this.Map(p => p.Account)
            //    .Ignore();
            this.Map(p => p.IsExpense)
                .Ignore();

            this.Map(p => p.Id)
                .IsIdentity()
                .IsKey();
            this.Map(p => p.Identifier);
            this.Map(p => p.AccountId);
            this.Map(p => p.Description);
            this.Map(p => p.Date);
            this.Map(p => p.Value);
            this.Map(p => p.CreatedOn);
            this.Map(p => p.LastUpdatedOn);
            this.Map(p => p.Status);
        }
    }
}