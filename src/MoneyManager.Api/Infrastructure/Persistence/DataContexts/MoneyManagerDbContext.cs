using Microsoft.EntityFrameworkCore;
using MoneyManager.Api.Domain.Entities;

namespace MoneyManager.Api.Infrastructure.Persistence.DataContexts
{
    public class MoneyManagerDbContext : DbContext
    {
        public MoneyManagerDbContext(DbContextOptions<MoneyManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}