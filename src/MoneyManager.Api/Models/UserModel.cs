﻿using MoneyManager.Api.Domain.Entities;
using System;

namespace MoneyManager.Api.Models
{
    public class UserModel
    {
        public Guid Identifier { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastUpdatedOn { get; set; }
        public bool IsActive { get; set; }

        public static UserModel FromUser(User entity)
        {
            return new UserModel()
            {
                Identifier = entity.Identifier,
                Login = entity.Login,
                FullName = entity.FullName,
                CreatedOn = entity.CreatedOn,
                LastUpdatedOn = entity.LastUpdatedOn,
                IsActive = entity.IsActive
            };
        }

        public User ToUser()
        {
            return new User()
            {
                Identifier = this.Identifier,
                Login = this.Login,
                Password = this.Password,
                FullName = this.FullName,
                CreatedOn = this.CreatedOn,
                LastUpdatedOn = this.LastUpdatedOn,
                IsActive = this.IsActive
            };
        }
    }
}