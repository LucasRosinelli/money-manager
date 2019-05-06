using System;

namespace MoneyManager.Domain.Entities
{
    public class Expense : Entry
    {
        protected Expense()
            : base(true)
        {
        }

        public Expense(long accountId, string description, DateTime date, float value)
            : base(true, accountId, description, date, value)
        {
        }
    }
}