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
            builder.HasKey(crane => crane.Id)
                .ForSqlServerIsClustered(false);

            builder
                .Property(crane => crane.Id)
                .HasColumnType("char(36)");

            builder
                .Property(crane => crane.Name)
                .HasColumnType("nvarchar(32)")
                .IsRequired();

            builder
                .Property(crane => crane.Title)
                .HasColumnType("nvarchar(128)");

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar(512)");

            builder.Property(x => x.Icon)
                .HasColumnType("nvarchar(256)");

            builder
                .Property(crane => crane.ImagePath)
                .HasColumnType("varchar(256)");

            builder
                .Property(crane => crane.OnCreated)
                .IsRequired();

            builder
                .HasIndex(crane => crane.OnCreated)
                .ForSqlServerIsClustered(true);
        }
    }
}
