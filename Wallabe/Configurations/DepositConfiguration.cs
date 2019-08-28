using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallabe.Domains;

namespace Wallabe.Configurations
{

    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            builder
                .HasKey(x => x.TransactionId);

            builder
                .Property(x => x.Amount)
                .HasColumnType("decimal(38, 18)");

            builder.HasOne(x => x.Transaction)
                .WithOne(y => y.Deposit)
                .HasForeignKey<Deposit>(x => x.TransactionId);
        }
    }
}
