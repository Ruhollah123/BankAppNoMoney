using Entities.Base;
using Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

public class SecurityTransactionConfiguration : IEntityTypeConfiguration<SecurityTransactionBase>
{
    public void Configure(EntityTypeBuilder<SecurityTransactionBase> builder)
    {

        builder.HasDiscriminator<string>("SecurityTransactionType")
            .HasValue<MutualFundTransaction>(nameof(MutualFundTransaction))
            .HasValue<StockTransaction>(nameof(StockTransaction));
    }
}
