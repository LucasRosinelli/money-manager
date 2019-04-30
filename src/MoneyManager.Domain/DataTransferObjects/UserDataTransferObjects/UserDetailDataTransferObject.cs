using MoneyManager.Domain.Contracts.DataTransferObjects;
using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.DataTransferObjects.UserDataTransferObjects
{
    /// <summary>
    /// User detail.
    /// </summary>
    public class UserDetailDataTransferObject : IDataTransferObject
    {
        /// <summary>
        /// User unique identifier.
        /// </summary>
        public Guid Identifier { get;  set; }
        /// <summary>
        /// User login.
        /// </summary>
        public string Login { get;  set; }
        /// <summary>
        /// User full name.
        /// </summary>
        public string FullName { get;  set; }
        /// <summary>
        /// Date, time and timezone when the user was created.
        /// </summary>
        public DateTimeOffset CreatedOn { get;  set; }
        /// <summary>
        /// Date, time and timezone when the user data was last updated.
        /// </summary>
        public DateTimeOffset? LastUpdatedOn { get;  set; }
        /// <summary>
        /// User status.
        /// </summary>
        public DefaultState Status { get;  set; }

        /// <summary>
        /// Initializes an empty user.
        /// </summary>
        public UserDetailDataTransferObject()
        {
        }

        /// <summary>
        /// Initializes an user based on user entity.
        /// </summary>
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