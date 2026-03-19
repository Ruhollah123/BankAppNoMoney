using Entities.Base;

namespace Entities.Accounts;

public class BankAccount : AccountBase
{
    public BankAccount()
    {
    }

    public BankAccount(string accountName, string accountNumber, decimal startingBalance, decimal interestRate = 1.0m)
        : base(accountName, accountNumber, startingBalance, interestRate)
    {
    }
}

