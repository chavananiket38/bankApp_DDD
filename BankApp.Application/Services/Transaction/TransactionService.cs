
using BankApp.Application.Common.Interfaces.Persistence;
using BankApp.Domain.Entities;
using System.Transactions;

namespace BankApp.Application.Services.Transaction;

public class TransactionService : ITransactionService{

    private readonly IAccountRepository _accountRepository;

    public TransactionService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public TransactionResult Withdrawal(string accountNumber, string password, decimal amount){
        var account = _accountRepository.GetAccountByAccountNumber(accountNumber);
        if(account is null){
            throw new Exception("Account with given account number does not exist");
        }

        if(account.AccountNumber != accountNumber){
            throw new Exception("Invalid Account Number");
        }

        if(amount<1 || amount>account.AccountBalance || amount>account.AccountLimit){
            throw new Exception("Invalid amount or amount is greater than account balance, account balance = " + account.AccountBalance );
        }

        if(password != account.Password){
            throw new Exception("Wrong password, transaction failed");
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
            throw new Exception("Invalid amount, Daily account limit = " + account.AccountLimit);
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

    public FundTransferResult FundTransfer(string sourceAccountNumber, string destinationAccountNumber,
    string sourceAccountPassword, decimal amount){
        var SourceAccount = _accountRepository.GetAccountByAccountNumber(sourceAccountNumber);
        var DestinationAccount = _accountRepository.GetAccountByAccountNumber(destinationAccountNumber);

        if (SourceAccount is null)
                throw new InvalidOperationException("The Source Account Number is Invalid.");

            
        if (DestinationAccount is null)
            throw new InvalidOperationException("The Destination Account Number is Invalid.");

        using var txnScope = new TransactionScope(TransactionScopeOption.RequiresNew);
        try
        {

            Withdrawal(sourceAccountNumber, sourceAccountPassword, amount);

            Deposit(destinationAccountNumber, amount);

            txnScope.Complete();
        } catch (Exception ex)
        {
            txnScope.Dispose();
            
            throw new Exception(ex.Message);
            throw new Exception("Transaction Failed");
        }

        return new FundTransferResult(
            SourceAccount.AccountNumber,
            SourceAccount.AccountBalance,
            DestinationAccount.AccountNumber,
            DestinationAccount.AccountBalance
        );
    }

}