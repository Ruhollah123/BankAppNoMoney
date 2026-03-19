using Entities.Accounts;
using Entities.Transactions;

namespace EntitiesTests.Accounts;

public class IskAccountTests
{

    private StockTransaction GetStockTransaction(int quantity = 1, decimal purchaseAmount = 1000)
    {
        return new StockTransaction
        {
            Id = Guid.NewGuid(),
            Quantity = quantity,
            PurchasePrice = purchaseAmount,
            PurchaseDate = DateTime.UtcNow,
        };
    }

    [Fact]
    public void Transfer()
    {
        var bankAccount = new BankAccount("bankAccount", "1234", 0, 2);
        var iskAccount = new IskAccount("IskAccount", "6789", 500, 3);

        bankAccount.Deposit(4000);

        bankAccount.Transfer(iskAccount, 1000);

        Assert.Equal(3000, bankAccount.Balance());
        Assert.Equal(1500, iskAccount.Balance());
    }





    [Fact]
    public void IskAccount_Balance_ResultShouldBeZero()
    {
        var account = new IskAccount("test", "123", 0);

        var result = account.Balance();

        Assert.Equal(0, result);
    }


    [Fact]
    public void IskAccount_Balance_SecurityDepositShouldBe1000()
    {
        var account = new IskAccount("test", "123", 0);

        var transaction = new StockTransaction
        {
            Id = Guid.NewGuid(),
            Quantity = 1,
            PurchasePrice = 1000,
            PurchaseDate = DateTime.UtcNow,
        };

        account.AddSecurityTransaction(transaction);

        var result = account.Balance();

        Assert.Equal(1000, result);
    }

    [Fact]
    public void IskAccount_Balance_AddMutualFundTransaction_DepositShouldBe1000()
    {
        var account = new IskAccount("test", "123", 0);
        var transaction = GetStockTransaction(1, 1000);
        account.AddSecurityTransaction(transaction);

        var result = account.Balance();

        Assert.Equal(1000, result);
    }


    [Fact]
    public void IskAccount_Balance_AddTwoDifferentTransactions_ShouldBe2000()
    {
        var account = new IskAccount("test", "123", 0);
        var fundTransaction = new StockTransaction { Id = Guid.NewGuid(), Quantity = 1, PurchasePrice = 1000, PurchaseDate = DateTime.UtcNow };
        var stockTransaction = GetStockTransaction(1, 1000);

        account.AddSecurityTransaction(fundTransaction);
        account.AddSecurityTransaction(stockTransaction);

        var result = account.Balance();

        Assert.Equal(2000m, result);
    }

    [Fact]
    public void BankAccount_Balance_ReturnAnAccountWithBalance()
    {
        var bankAccount = new IskAccount("test", "123", 500, 1);

        bankAccount.Deposit(1000);

        var mutualAccount = new MutualFundTransaction()
        {
            Quantity = 1,
            PurchasePrice = 500,
            PurchaseDate = DateTime.Now
        };

        var stockAccount = new StockTransaction()
        {
            Quantity = 1,
            PurchasePrice = 500,
            PurchaseDate = DateTime.Now
        };


        bankAccount.AddSecurityTransaction(mutualAccount);
        bankAccount.AddSecurityTransaction(stockAccount);

        bankAccount.Withdraw(2000);

        Assert.Equal(500, bankAccount.Balance());
    }








    [Theory]
    [InlineData()]
    public void IskAccount_Balance_()
    {

    }
}
