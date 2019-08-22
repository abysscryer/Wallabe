using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Data
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
               .Property(product => product.Id)
               .HasColumnType("char(36)");

            builder
                .Property(product => product.OnCreated)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.HasOne(product => product.Crane)
                .WithMany(crane => crane.Products)
                .HasForeignKey(product => product.CraneId)
                .IsRequired();
        }
    }
}