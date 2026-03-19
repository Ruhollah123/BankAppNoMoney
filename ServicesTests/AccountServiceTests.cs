using EFCore.Repositories;
using Entities.Accounts;
using Entities.Base;
using Entities.Types;
using NSubstitute;
using Services;
using Services.Interfaces;
using Services.Models;

namespace ServicesTests;

public class AccountServiceTests
{
    private readonly IAccountRepository _accountRepository;

    public AccountServiceTests()
    {
        var mock = Substitute.For<IAccountRepository>();
        _accountRepository = mock;
    }

    [Fact]
    public void AccountService_CreateAccount_RepositoryThrowsError_ShouldReturnFalse()
    {
        //Arrang 
        _accountRepository.Add(Arg.Any<AccountBase>()).Returns(_ => throw new NullReferenceException());
        var service = new AccountService(_accountRepository);
        var accountDetails = new AccountDetails("test", "123", 0, AccountType.UddevallaAccount);

        //Add
        var result = service.CreateNewAccount(accountDetails);

        //Assert
        Assert.False(result);
    }
    [Fact]
    public void AccountService_CreateAccount_ShouldReturnTrue()
    {
        var service = new AccountService(_accountRepository);
        var accountDetails = new AccountDetails("test", "123", 0, AccountType.UddevallaAccount);

        var result = service.CreateNewAccount(accountDetails);

        Assert.True(result);
    }

    [Fact]
    public void AccountService_GetAllAccounts_ShouldReturnTwoItems()
    {
        _accountRepository.GetAll().Returns([
        new BankAccount("test", "111", 0),
        new UddevallaAccount("test2", "1234", 100)
        ]);

        var service = new AccountService(_accountRepository);

        var result = service.GetAllAccounts();

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void AccountService_GetAllAccounts_ShouldReturnZero()
    {
        _accountRepository.GetAll().Returns([]);

        var service = new AccountService(_accountRepository);

        var result = service.GetAllAccounts();

        Assert.Empty(result);
    }

    [Fact]
    public void AccountService_GetAllAccounts_TestService1()
    {
        var repository = new AccountRepository(new EFCore.BankContext());

        var service = new AccountService(repository);

        var result = service.GetAllAccounts();

        Assert.Empty(result);
    }

    [Fact]
    public void AccountService_GetAllAccounts_TestService()
    {
        var repository = new AccountRepository(new EFCore.BankContext());

        var service = new AccountService(repository);

        var result = service.GetAllAccounts();

        Assert.Empty(result);
    }

    [Fact]
    public void AccountService_GetAllAccounts_TestService2()
    {
        var repository = new AccountRepository(new EFCore.BankContext());

        var service = new AccountService(repository);

        var result = service.GetAllAccounts();

        Assert.Empty(result);
    }

    [Fact]
    public void AccountService_GetAllAccounts_TestService3()
    {
        var repository = new AccountRepository(new EFCore.BankContext());

        var service = new AccountService(repository);

        var result = service.GetAllAccounts();

        Assert.Empty(result);
    }
}
