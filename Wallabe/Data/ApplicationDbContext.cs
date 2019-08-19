using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallabe.Configurations;
using Wallabe.Domains;

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

        public DbSet<Rank> Ranks { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CraneConfiguration());
            builder.ApplyConfiguration(new DollConfiguration());
            builder.ApplyConfiguration(new RankConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
