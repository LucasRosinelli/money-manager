using MoneyManager.Domain.Contracts.DataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.DataTransferObjects.UserDataTransferObject
{
    public class UserDetailDataTransferObject : IDataTransferObject
    {
        public Guid Identifier { get;  set; }
        public string Login { get;  set; }
        public string FullName { get;  set; }
        public DateTimeOffset CreatedOn { get;  set; }
        public DateTimeOffset? LastUpdatedOn { get;  set; }
        public DefaultState Status { get;  set; }

        public UserDetailDataTransferObject()
        {
        }

        public UserDetailDataTransferObject(User user)
        {
            if (user != null)
            {
                this.Identifier = user.Identifier;
                this.Login = user.Login;
                this.FullName = user.FullName;
                this.CreatedOn = user.CreatedOn;
                this.LastUpdatedOn = user.LastUpdatedOn;
                this.Status = user.Status;
            }
        }
    }
}