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
                .HasKey(product => product.Id)
                .ForSqlServerIsClustered(false);

            builder
               .Property(product => product.Id)
               .HasColumnType("char(36)");

            builder
                .Property(product => product.OnCreated)
                .IsRequired();

            builder.HasOne(product => product.Crane)
                .WithMany(crane => crane.Products)
                .HasForeignKey(product => product.CraneId)
                .IsRequired();

            builder
                .HasIndex(product => product.OnCreated)
                .ForSqlServerIsClustered(true);
        }
    }
}