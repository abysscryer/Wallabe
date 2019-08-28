using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                .HasKey(x => x.Id)
                .ForSqlServerIsClustered(false);

            builder.Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .Property(x => x.BeforeAmount)
                .HasColumnType("decimal(38, 18)");
            builder
                .Property(x => x.ApplyAmount)
                .HasColumnType("decimal(38, 18)");
            builder
                .Property(x => x.AfterAmount)
                .HasColumnType("decimal(38, 18)");

            builder
                .HasIndex(x => x.OnCreated)
                .ForSqlServerIsClustered(true);
        }
    }
}
