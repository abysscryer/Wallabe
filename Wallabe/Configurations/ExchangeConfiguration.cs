using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class ExchangeConfiguration : IEntityTypeConfiguration<Exchange>
    {
        public void Configure(EntityTypeBuilder<Exchange> builder)
        {
            builder
                .HasKey(x => x.TransactionId);

            builder.HasOne(x => x.Transaction)
                .WithOne(y => y.Exchange)
                .HasForeignKey<Exchange>(x => x.TransactionId);

            builder.HasOne(x => x.Doll)
                .WithMany(y => y.Exchanges)
                .HasForeignKey(x => x.DollId)
                .IsRequired();
        }
    }
}
