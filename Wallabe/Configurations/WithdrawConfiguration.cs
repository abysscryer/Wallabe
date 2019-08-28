using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class WithdrawConfiguration : IEntityTypeConfiguration<Withdraw>
    {
        public void Configure(EntityTypeBuilder<Withdraw> builder)
        {
            builder
                .HasKey(x => x.TransactionId);

            builder
                .Property(x => x.Amount)
                .HasColumnType("decimal(38, 18)");

            builder
                .HasOne(x => x.Transaction)
                .WithOne(y => y.Withdraw)
                .HasForeignKey<Withdraw>(x => x.TransactionId);
        }
    }
}
