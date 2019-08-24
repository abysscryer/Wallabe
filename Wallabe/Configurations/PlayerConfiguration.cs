using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasKey(player => player.Id)
                .ForSqlServerIsClustered(false);

            builder
                .Property(palyer => palyer.Id)
                .HasColumnType("char(36)");

            builder
                .Property(palyer => palyer.Name)
                .HasColumnType("nvarchar(32)")
                .IsRequired();

            builder
                .Property(player => player.ImagePath)
                .HasColumnType("varchar(256)");

            builder
                .Property(player => player.OnCreated)
                .IsRequired();

            builder
                .HasIndex(player => player.Name)
                .IsUnique()
                .ForSqlServerIsClustered(true);
        }
    }
}
