using Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankContext).Assembly);
    }
}