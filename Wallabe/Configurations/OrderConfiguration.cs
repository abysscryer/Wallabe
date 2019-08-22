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
                .Property(order => order.Id)
                .HasColumnType("char(36)");

            builder
                .Property(order => order.OnCreated)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            builder.HasOne(order => order.Player)
                .WithMany(player => player.Orders)
                .HasForeignKey(order => order.PlayerId)
                .IsRequired();

            builder.HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId)
                .IsRequired();
        }
    }
}