namespace BankApp.Application.Services.Transaction;

public interface ITransactionService{
    TransactionResult Deposit(string accountNumber, decimal amount);
    TransactionResult Withdrawal(string accountNumber, string password, decimal amount);
    FundTransferResult FundTransfer(string sourceAccountNumber, string destinationAccountNumber,
    string sourceAccountPassword, decimal amount);
}