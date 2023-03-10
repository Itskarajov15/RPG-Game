using Microsoft.EntityFrameworkCore;
using RPG.Data.Models;

namespace RPG.Data
{
    public class RPGDbContext : DbContext
    {
        public DbSet<Hero> Heroes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}