using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Enums;
using MoneyManager.Domain.Scopes;
using System;

namespace MoneyManager.Domain.Entities
{
    public class Account : IEntityExtended<DefaultState>
    {
        public long Id { get; private set; }
        public Guid Identifier { get; private set; }
        public long UserId { get; private set; }
        //public virtual User User { get; private set; }
        public string ShortName { get; private set; }
        public string LongName { get; private set; }
        public string Color { get; private set; }
        public string Icon { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset? LastUpdatedOn { get; private set; }
        public DefaultState Status { get; private set; }

        protected Account()
        {
            this.Identifier = Guid.NewGuid();
            this.CreatedOn = DateTimeOffset.Now;
            this.Status = DefaultState.Active;
        }

        public Account(long userId, string shortName, string longName, string color, string icon)
            : this()
        {
            this.UserId = userId;
            this.ShortName = shortName;
            this.LongName = longName;
            this.Color = color;
            this.Icon = icon;
        }

        public bool Register()
        {
            return this.RegisterIsValid();
        }

        public bool ChangeInfo(string shortName, string longName, string color, string icon)
        {
            if (this.ChangeInfoIsValid(shortName, longName, color, icon))
            {
                this.ShortName = shortName;
                this.LongName = longName;
                this.Color = color;
                this.Icon = icon;
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