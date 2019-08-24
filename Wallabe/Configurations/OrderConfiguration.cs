using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(order => order.Id)
                .ForSqlServerIsClustered(false);

            builder
                .Property(order => order.Id)
                .HasColumnType("char(36)");

            builder
                .Property(order => order.OnCreated)
                .IsRequired();

            builder.HasOne(order => order.Player)
                .WithMany(player => player.Orders)
                .HasForeignKey(order => order.PlayerId)
                .IsRequired();

            builder.HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId)
                .IsRequired();

            builder
                .HasIndex(order => order.OnCreated)
                .ForSqlServerIsClustered(true);
        }
    }
}