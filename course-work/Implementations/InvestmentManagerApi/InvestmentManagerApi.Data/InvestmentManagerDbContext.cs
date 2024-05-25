using InvestmentManagerApi.Data.Entities;
using InvestmentManagerApi.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManagerApi.Data
{
    public class InvestmentManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Etf> Etfs { get; set; }
        public DbSet<Investment> Investments { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Currency> Currencies { get; set; }

        public InvestmentManagerDbContext(DbContextOptions<InvestmentManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasData(new Currency
                {
                    Id = Guid.NewGuid(),
                    Code = "EUR",
                    Name = "Euro",
                    ToEuroRate = 1,
                    IsActivated = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                }, 
                new Currency
                {
                    Id = Guid.NewGuid(),
                    Code = "BGN",
                    Name = "Lev",
                    ToEuroRate = 1.95m,
                    IsActivated = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                },
                new Currency
                {
                    Id = Guid.NewGuid(),
                    Code = "USD",
                    Name = "American Dollar",
                    ToEuroRate = 0.93m,
                    IsActivated = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@admin.bg",
                    FirstName = "Georgi",
                    LastName = "Petkov",
                    Password = PasswordManager.HashPassword("admin"),
                    Age = 21,
                    IsActivated = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}
