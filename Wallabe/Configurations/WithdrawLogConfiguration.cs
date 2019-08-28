using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallabe.Domains;

namespace Wallabe.Configurations
{
    public class WithdrawLogConfiguration : IEntityTypeConfiguration<WithdrawLog>
    {
        public void Configure(EntityTypeBuilder<WithdrawLog> builder)
        {
            builder
                .HasKey(x => x.Id)
                .ForSqlServerIsClustered(false);

            builder.Property(x => x.Id)
                .HasColumnType("char(36)");

            builder
                .HasIndex(x => x.OnCreated)
                .ForSqlServerIsClustered(true);

            builder
                .HasOne(x => x.Withdraw)
                .WithMany(y => y.WithdrawLogs)
                .HasForeignKey(x => x.WithdrawId)
                .IsRequired();
        }
    }
}
