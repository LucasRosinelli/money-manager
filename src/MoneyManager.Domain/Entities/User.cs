using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.Entities
{
    public class User
    {
        public long Id { get; private set; }
        public Guid Identifier { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string FullName { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset? LastUpdatedOn { get; private set; }
        public DefaultState Status { get; private set; }

        protected User()
        {
            this.Identifier = Guid.NewGuid();
            this.CreatedOn = DateTimeOffset.Now;
            this.Status = DefaultState.Active;
        }

        public User(string login, string password, string fullName)
            : this()
        {
            this.Login = login;
            this.Password = password;
            this.FullName = fullName;
        }
    }
}