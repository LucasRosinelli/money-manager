using MoneyManager.Domain.Contracts.DataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.DataTransferObjects.AccountDataTransferObjects
{
    /// <summary>
    /// Account detail.
    /// </summary>
    public class AccountDetailDataTransferObject : IDataTransferObject
    {
        /// <summary>
        /// Account unique identifier.
        /// </summary>
        public Guid Identifier { get; set; }
        /// <summary>
        /// Account short name.
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Account long name.
        /// </summary>
        public string LongName { get; set; }
        /// <summary>
        /// Account RGB color.
        /// </summary>
        public string Color { get; set; }
        /// <summary>
        /// Account icon.
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// Account current balance.
        /// </summary>
        public float CurrentBalance { get; set; }
        /// <summary>
        /// Date, time and timezone when the account was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }
        /// <summary>
        /// Date, time and timezone when the account data was last updated.
        /// </summary>
        public DateTimeOffset? LastUpdatedOn { get; set; }
        /// <summary>
        /// Account status.
        /// </summary>
        public DefaultState Status { get; set; }

        /// <summary>
        /// Initializes an empty account.
        /// </summary>
        public AccountDetailDataTransferObject()
        {
        }

        /// <summary>
        /// Initializes an account based on account entity.
        /// </summary>
        /// <param name="account">Account data to be used.</param>
        public AccountDetailDataTransferObject(Account account)
        {
            if (account != null)
            {
                this.Identifier = account.Identifier;
                this.ShortName = account.ShortName;
                this.LongName = account.LongName;
                this.Color = account.Color;
                this.Icon = account.Icon;
                this.CurrentBalance = account.CurrentBalance;
                this.CreatedOn = account.CreatedOn;
                this.LastUpdatedOn = account.LastUpdatedOn;
                this.Status = account.Status;
            }
        }
    }
}