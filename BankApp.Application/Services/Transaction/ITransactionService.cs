namespace BankApp.Application.Services.Transaction;

public interface ITransactionService{
    TransactionResult Deposit(string accountNumber, decimal amount);
    TransactionResult Withdrawal(string accountNumber, decimal amount);
}