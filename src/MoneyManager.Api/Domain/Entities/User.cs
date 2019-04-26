using System;

namespace MoneyManager.Api.Domain.Entities
{
    public class User
    {
        public long Id { get; set; }
        public Guid Identifier { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}