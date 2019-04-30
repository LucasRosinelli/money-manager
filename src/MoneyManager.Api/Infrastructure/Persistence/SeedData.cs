using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyManager.Infrastructure.Persistence.DataContexts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Api.Infrastructure.Persistence
{
    public class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<MoneyManagerDbContext>();
            await FakeUsersAsync(context);
        }

        private static async Task FakeUsersAsync(MoneyManagerDbContext context)
        {
            var testUser = await context.Users
                .Where(u => u.Login == Constants.TestUserLogin)
                .SingleOrDefaultAsync();

            if (testUser != null)
            {
                return;
            }

            var identifier = Guid.NewGuid();

            await context.Users.AddAsync(new MoneyManager.Domain.Entities.User(Constants.TestUserLogin, Constants.TestUserPassword, Constants.TestUserFullName));

            await context.SaveChangesAsync();
        }
    }
}