using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class PlayConfiguration : IEntityTypeConfiguration<Play>
    {
        public void Configure(EntityTypeBuilder<Play> builder)
        {
            builder
                .Property(play => play.Id)
                .HasColumnType("char(36)");

            builder
                .Property(Play => Play.OnCreated)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder
                .HasOne(play => play.Game)
                .WithMany(game => game.Plays)
                .HasForeignKey(Play => Play.GameId)
                .IsRequired();
        }
    }
}
