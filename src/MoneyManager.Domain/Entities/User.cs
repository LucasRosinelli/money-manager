using MoneyManager.Domain.Enums;
using MoneyManager.Domain.Scopes;
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

        public bool Register()
        {
            return this.RegisterIsValid();
        }

        public bool ChangeAuthInfo(string login, string password)
        {
            if (this.ChangeAuthInfoIsValid(login, password))
            {
                this.Login = login;
                this.Password = password;
                this.LastUpdatedOn = DateTimeOffset.Now;

                return true;
            }

            return false;
        }

        public bool ChangeBasicInfo(string fullName)
        {
            if (this.ChangeBasicInfoIsValid(fullName))
            {
                this.FullName = fullName;
                this.LastUpdatedOn = DateTimeOffset.Now;

                return true;
            }

            return false;
        }

        public bool Activate()
        {
            if (this.ActivateIsValid())
            {
                this.Status = DefaultState.Active;

                return true;
            }

            return false;
        }

        public bool Deactivate()
        {
            if (this.DeactivateIsValid())
            {
                this.Status = DefaultState.Inactive;

                return true;
            }

            return false;
        }
    }
}