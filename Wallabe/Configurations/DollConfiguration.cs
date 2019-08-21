using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class DollConfiguration : IEntityTypeConfiguration<Doll>
    {
        public void Configure(EntityTypeBuilder<Doll> builder)
        {
            builder
                .Property(doll => doll.Id)
                .HasColumnType("char(36)");

            builder
                .Property(doll => doll.Name)
                .HasColumnType("nvarchar(32)")
                .IsRequired();

            builder
                .HasOne(doll => doll.Crane)
                .WithMany(crane => crane.Dolls)
                .HasForeignKey(doll => doll.CraneId);

            builder
                .Property(doll => doll.OnCreated)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder
                .Property(doll => doll.ImagePath)
                .HasColumnType("varchar(256)");
        }
    }
}
