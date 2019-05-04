using Dapper.FluentMap.Dommel.Mapping;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infrastructure.Persistence.Map
{
    public class AccountMap : DommelEntityMap<Account>
    {
        public AccountMap()
        {
            this.ToTable("Accounts");

            //this.Map(p => p.User)
            //    .Ignore();

            this.Map(p => p.Id)
                .IsIdentity()
                .IsKey();
            this.Map(p => p.Identifier);
            this.Map(p => p.UserId);
            this.Map(p => p.ShortName);
            this.Map(p => p.LongName);
            this.Map(p => p.Color);
            this.Map(p => p.Icon);
            this.Map(p => p.CreatedOn);
            this.Map(p => p.LastUpdatedOn);
            this.Map(p => p.Status);
        }
    }
}