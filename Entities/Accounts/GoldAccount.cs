using Entities.Base;

namespace Entities.Accounts;

public class GoldAccount : AccountBase
{
    public GoldAccount()
    {
        
    }
    public GoldAccount(string accountName, string accountNumber, decimal startingBalance, decimal interestRate = 1.0m)
        : base(accountName, accountNumber, startingBalance, interestRate) { }
}
