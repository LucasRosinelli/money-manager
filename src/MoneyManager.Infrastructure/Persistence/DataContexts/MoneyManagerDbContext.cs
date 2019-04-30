using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Infrastructure.Persistence.DataContexts
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