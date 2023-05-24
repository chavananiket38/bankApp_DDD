using BankApp.Application.Common.Interfaces.Persistence;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Accounts;

public class AccountService : IAccountService{

    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public AccountResult GetAccountDetails(string accountNumber){
        var account = _accountRepository.GetAccountByAccountNumber(accountNumber);

        if(account is null){
            throw new Exception("Invalid account number or account does not exist");
        }

        return new AccountResult(
            account.AccountNumber,
            account.FirstName,
            account.LastName,
            account.Email,
            account.Gender,
            account.City,
            account.AccountBalance
        );
    }
}