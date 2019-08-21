using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class CraneRecordConfiguration : IEntityTypeConfiguration<CraneRecord>
    {
        public void Configure(EntityTypeBuilder<CraneRecord> builder)
        {
            builder
                .HasKey(record => new { record.Date, record.CraneId, record.PlayerId });

            builder
                .Property(record => record.Date)
                .HasColumnType("char(8)");

            builder
                .HasOne(record => record.Crane)
                .WithMany(crane => crane.CraneRecords)
                .HasForeignKey(record => record.CraneId);

            builder
                .HasOne(record => record.Player)
                .WithMany(player => player.CraneRecords)
                .HasForeignKey(record => record.PlayerId);
        }
    }
}
