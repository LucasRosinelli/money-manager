using MoneyManager.Domain.Contracts.DataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.DataTransferObjects.ExpenseDataTransferObjects
{
    public class ExpenseDetailDataTransferObject : IDataTransferObject
    {
        /// <summary>
        /// Expense unique identifier.
        /// </summary>
        public Guid Identifier { get; set; }
        /// <summary>
        /// Expense description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Expense date occurred.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Expense value.
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Date, time and timezone when the expense was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }
        /// <summary>
        /// Date, time and timezone when the expense data was last updated.
        /// </summary>
        public DateTimeOffset? LastUpdatedOn { get; set; }
        /// <summary>
        /// Expense status.
        /// </summary>
        public DefaultState Status { get; set; }

        /// <summary>
        /// Initializes an empty expense.
        /// </summary>
        public ExpenseDetailDataTransferObject()
        {
        }

        /// <summary>
        /// Initializes an expense based on expense entity.
        /// </summary>
        /// <param name="expense">Expense data to be used.</param>
        public ExpenseDetailDataTransferObject(Expense expense)
        {
            if (expense != null)
            {
                this.Identifier = expense.Identifier;
                this.Description = expense.Description;
                this.Date = expense.Date;
                this.Value = expense.Value;
                this.CreatedOn = expense.CreatedOn;
                this.LastUpdatedOn = expense.LastUpdatedOn;
                this.Status = expense.Status;
            }
        }
    }
}