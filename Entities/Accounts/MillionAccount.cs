using Entities.Base;

namespace Entities.Accounts;

public class MillionAccount : AccountBase
{
    public MillionAccount() { }

    public MillionAccount(string accountName, string accountNumber, decimal startingBalance, decimal interestRate = 1.0m)
        : base(accountName, accountNumber, startingBalance, interestRate) { }
}
