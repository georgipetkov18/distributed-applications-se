﻿using InvestmentManagerApi.Data.Entities;
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
    }
}
