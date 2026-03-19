using Entities.Accounts;
using Entities.Base;
using Entities.Security;
using Entities.Transactions;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class BankContext : DbContext
{
    public DbSet<AccountBase> AccountBases { get; set; }
    public DbSet<SecurityBase> SecurityBases { get; set; }
    public DbSet<SecurityTransactionBase> SecurityTransactions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BankDatabase;Trusted_Connection=True");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountBase>().HasDiscriminator<string>("AccountType")
            .HasValue<UddevallaAccount>(nameof(UddevallaAccount))
            .HasValue<BankAccount>(nameof(BankAccount))
            .HasValue<GoldAccount>(nameof(GoldAccount))
            .HasValue<IskAccount>(nameof(IskAccount))
            .HasValue<MillionAccount>(nameof(MillionAccount));

        modelBuilder.Entity<SecurityBase>().HasDiscriminator<string>("SecurityType")
            .HasValue<MutualFund>(nameof(MutualFund))
            .HasValue<Stock>(nameof(Stock));

        modelBuilder.Entity<SecurityTransactionBase>().HasDiscriminator<string>("SecurityTransactionType")
            .HasValue<MutualFundTransaction>(nameof(MutualFundTransaction))
            .HasValue<StockTransaction>(nameof(StockTransaction));
    }
}
