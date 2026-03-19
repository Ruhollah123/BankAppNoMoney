using Entities.Accounts;
using Entities.Base;
using Entities.Security;
using Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations;

internal class AccountBaseConfiguration : IEntityTypeConfiguration<AccountBase>
{
    public void Configure(EntityTypeBuilder<AccountBase> builder)
    {
        builder.HasDiscriminator<string>("AccountType")
            .HasValue<UddevallaAccount>(nameof(UddevallaAccount))
            .HasValue<BankAccount>(nameof(BankAccount))
            .HasValue<GoldAccount>(nameof(GoldAccount))
            .HasValue<IskAccount>(nameof(IskAccount))
            .HasValue<MillionAccount>(nameof(MillionAccount));
    }
}
