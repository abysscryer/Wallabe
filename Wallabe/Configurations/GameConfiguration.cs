using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .Property(game => game.Id)
                .HasColumnType("char(36)");

            builder
                .Property(game => game.OnCreated)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder
                .HasOne(game => game.Player)
                .WithMany(player => player.Games)
                .HasForeignKey(game => game.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(game => game.Crane)
                .WithMany(crane => crane.Games)
                .HasForeignKey(game => game.CraneId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(game => game.Order)
                .WithMany(order => order.Games)
                .HasForeignKey(game => game.OrderId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
