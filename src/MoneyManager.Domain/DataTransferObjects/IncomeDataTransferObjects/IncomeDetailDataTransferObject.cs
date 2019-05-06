using MoneyManager.Domain.Contracts.DataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.DataTransferObjects.IncomeDataTransferObjects
{
    public class IncomeDetailDataTransferObject : IDataTransferObject
    {
        /// <summary>
        /// Income unique identifier.
        /// </summary>
        public Guid Identifier { get; set; }
        /// <summary>
        /// Income description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Income date occurred.
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Income value.
        /// </summary>
        public float Value { get; set; }
        /// <summary>
        /// Date, time and timezone when the income was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get; set; }
        /// <summary>
        /// Date, time and timezone when the income data was last updated.
        /// </summary>
        public DateTimeOffset? LastUpdatedOn { get; set; }
        /// <summary>
        /// Income status.
        /// </summary>
        public DefaultState Status { get; set; }

        /// <summary>
        /// Initializes an empty income.
        /// </summary>
        public IncomeDetailDataTransferObject()
        {
        }

        /// <summary>
        /// Initializes an income based on expense entity.
        /// </summary>
        /// <param name="income">Income data to be used.</param>
        public IncomeDetailDataTransferObject(Income income)
        {
            if (income != null)
            {
                this.Identifier = income.Identifier;
                this.Description = income.Description;
                this.Date = income.Date;
                this.Value = income.Value;
                this.CreatedOn = income.CreatedOn;
                this.LastUpdatedOn = income.LastUpdatedOn;
                this.Status = income.Status;
            }
        }
    }
}