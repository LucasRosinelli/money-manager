using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Domain.Entities;
using MoneyManager.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace MoneyManager.Api.Infrastructure.Persistence
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            await FakeUsersAsync(unitOfWork);
        }

        private static async Task FakeUsersAsync(IUnitOfWork unitOfWork)
        {
            using (var connection = unitOfWork.GetConnection())
            {
                var testUser = await connection.QuerySingleOrDefaultAsync<User>("SELECT * FROM [Users] U WHERE U.[Login] = @Login", new { Login = Constants.TestUserLogin });

                if (testUser != null)
                {
                    return;
                }

                var user = new User(Constants.TestUserLogin, Constants.TestUserPassword, Constants.TestUserFullName);
                var id = await connection.InsertAsync<User>(user);
            }
        }
    }
}