using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder
                .HasKey(x => x.TransactionId);

            builder.HasOne(x => x.Transaction)
                .WithOne(y => y.Payment)
                .HasForeignKey<Payment>(y => y.TransactionId);

            builder
                .HasOne(x => x.Order)
                .WithOne(y => y.Payment)
                .HasForeignKey<Payment>(x => x.OrderId)
                .IsRequired();
        }
    }
}
