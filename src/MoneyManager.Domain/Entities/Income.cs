using System;

namespace MoneyManager.Domain.Entities
{
    public class Income : Entry
    {
        protected Income()
            : base(false)
        {
        }

        public Income(long accountId, string description, DateTime date, float value)
            : base(false, accountId, description, date, value)
        {
        }
    }
}