using MoneyManager.Domain.Contracts.Entities;
using MoneyManager.Domain.Enums;
using MoneyManager.Domain.Scopes;
using System;

namespace MoneyManager.Domain.Entities
{
    public abstract class Entry : IEntityExtended<DefaultState>
    {
        public long Id { get; private set; }
        public Guid Identifier { get; private set; }
        public long AccountId { get; private set; }
        //public virtual Account Account { get; private set; }
        public bool IsExpense { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public float Value { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; }
        public DateTimeOffset? LastUpdatedOn { get; private set; }
        public DefaultState Status { get; private set; }

        protected Entry(bool isExpense)
        {
            this.Identifier = Guid.NewGuid();
            this.CreatedOn = DateTimeOffset.Now;
            this.Status = DefaultState.Active;
        }

        public Entry(bool isExpense, long accountId, string description, DateTime date, float value)
            : this(isExpense)
        {
            this.AccountId = accountId;
            this.Description = description;
            this.Date = date;
            this.Value = value;
        }

        public virtual bool Register()
        {
            return this.RegisterIsValid();
        }

        public virtual bool ChangeInfo(string description, DateTime date, float value)
        {
            if (this.ChangeInfoIsValid(description, date, value))
            {
                this.Description = description;
                this.Date = date;
                this.Value = value;
                this.LastUpdatedOn = DateTimeOffset.Now;

                return true;
            }

            return false;
        }

        public virtual bool Activate()
        {
            if (this.ActivateIsValid())
            {
                this.Status = DefaultState.Active;

                return true;
            }

            return false;
        }

        public virtual bool Deactivate()
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