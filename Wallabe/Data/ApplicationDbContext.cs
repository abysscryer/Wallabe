﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallabe.Configurations;
using Wallabe.Domains;
using Wallabe.Extensions;

namespace Wallabe.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Crane> Cranes { get; set; }

        public DbSet<Doll> Dolls { get; set; }

        public DbSet<Record> Records { get; set; }

        public DbSet<CraneRecord> CraneRecords { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Play> Plays { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Exchange> Exchanges { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Withdraw> Withdraws { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CraneConfiguration());
            builder.ApplyConfiguration(new DollConfiguration());

            builder.ApplyConfiguration(new RecordConfiguration());
            builder.ApplyConfiguration(new CraneRecordConfiguration());
            
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());

            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new GameConfiguration());
            builder.ApplyConfiguration(new PlayConfiguration());

            builder.ApplyConfiguration(new TransactionConfiguration());
            builder.ApplyConfiguration(new DepositConfiguration());
            builder.ApplyConfiguration(new ExchangeConfiguration());
            builder.ApplyConfiguration(new PaymentConfiguration());
            builder.ApplyConfiguration(new WithdrawConfiguration());

            builder.Seed();

            base.OnModelCreating(builder);
        }
    }
}
