using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class RecordConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        {
            builder
                .HasKey(record => new { record.Date, record.PlayerId });

            builder
                .Property(record => record.Date)
                .HasColumnType("char(8)");

            builder
                .HasOne(record => record.Player)
                .WithMany(player => player.Records)
                .HasForeignKey(record => record.PlayerId);
        }
    }
}
