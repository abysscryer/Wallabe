using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class RankConfiguration : IEntityTypeConfiguration<Rank>
    {
        public void Configure(EntityTypeBuilder<Rank> builder)
        {
            builder
                .HasKey(rank => new { rank.Date, rank.CraneId, rank.PlayerId });

            builder
                .Property(rank => rank.Date)
                .HasColumnType("char(8)");

            builder
                .HasOne(rank => rank.Crane)
                .WithMany(crane => crane.Ranks)
                .HasForeignKey(rank => rank.CraneId);
        }
    }
}
