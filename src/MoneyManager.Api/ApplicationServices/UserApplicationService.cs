﻿using Microsoft.EntityFrameworkCore;
using MoneyManager.Api.Domain.ApplicationServices;
using MoneyManager.Api.Domain.Entities;
using MoneyManager.Api.Infrastructure.Persistence.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Api.ApplicationServices
{
    public class UserApplicationService : ApplicationService, IUserApplicationService
    {
        public UserApplicationService(MoneyManagerDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await this.Context.Users.ToArrayAsync();
        }

        public async Task<User> GetAsync(Guid identifier)
        {
            var user = await this.Context.Users.
                Where(u => u.Identifier == identifier)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> CreateAsync(User entity)
        {
            this.Context.Users.Add(entity);
            await this.Context.SaveChangesAsync();

            return entity;
        }

        public async Task<User> UpdateAsync(Guid key, User entity)
        {
            if (key != entity.Identifier)
            {
                return null;
            }

            var user = await this.GetAsync(key);

            if (user == null)
            {
                return null;
            }

            user.Login = entity.Login;
            user.Password = entity.Password;
            user.FullName = entity.FullName;
            user.LastUpdatedOn = DateTimeOffset.Now;
            user.IsActive = entity.IsActive;

            this.Context.Entry(user).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();

            return user;
        }
    }
}