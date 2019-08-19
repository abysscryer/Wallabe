using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class CraneConfiguration : IEntityTypeConfiguration<Crane>
    {
        public void Configure(EntityTypeBuilder<Crane> builder)
        {
            builder
                .Property(crane => crane.Id)
                .HasColumnType("char(36)");

            builder
                .Property(crane => crane.Name)
                .HasColumnType("nvarchar(32)")
                .IsRequired();
        }
    }
}
