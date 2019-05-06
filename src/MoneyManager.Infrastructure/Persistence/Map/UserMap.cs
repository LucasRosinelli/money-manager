using Dapper.FluentMap.Dommel.Mapping;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infrastructure.Persistence.Map
{
    public class UserMap : DommelEntityMap<User>
    {
        public UserMap()
        {
            this.ToTable("Users");

            this.Map(p => p.Id)
                .IsIdentity()
                .IsKey();
            this.Map(p => p.Identifier);
            this.Map(p => p.Login);
            this.Map(p => p.Password);
            this.Map(p => p.FullName);
            this.Map(p => p.Balance);
            this.Map(p => p.CreatedOn);
            this.Map(p => p.LastUpdatedOn);
            this.Map(p => p.Status);
        }
    }
}