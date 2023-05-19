
using BankApp.Application.Common.Interfaces.Persistence;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Transaction;

public class TransactionService : ITransactionService{

    private readonly IAccountRepository _accountRepository;

    public TransactionService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public TransactionResult Withdrawal(string accountNumber, decimal amount){
        var account = _accountRepository.GetAccountByAccountNumber(accountNumber);
        if(account is null){
            throw new Exception("Account with given account number does not exist");
        }

        if(account.AccountNumber != accountNumber){
            throw new Exception("Invalid Account Number");
        }

        if(amount<1 || amount>account.AccountBalance || amount>account.AccountLimit){
            throw new Exception("Invalid amount or amount is greater than daily limit");
        }

        account.AccountBalance -= amount;

        _accountRepository.UpdateAccount(account);

        return new TransactionResult(
            account.AccountNumber,
            account.FirstName,
            account.LastName,
            account.Email,
            account.AccountBalance
        );
    }

    public TransactionResult Deposit(string accountNumber, decimal amount){
        var account = _accountRepository.GetAccountByAccountNumber(accountNumber);
        if(account is null){
            throw new Exception("Account with given Account Number does not exist");
        }

        if(account.AccountNumber != accountNumber){
            throw new Exception("Invalid Account Number");
        }

        if(amount<1 || amount>account.AccountLimit){
            throw new Exception("Invalid amount");
        }

        account.AccountBalance += amount;

        _accountRepository.UpdateAccount(account);

        return new TransactionResult(
            account.AccountNumber,
            account.FirstName,
            account.LastName,
            account.Email,
            account.AccountBalance
        );
    }

}