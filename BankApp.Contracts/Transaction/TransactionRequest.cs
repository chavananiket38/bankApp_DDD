namespace BankApp.Contracts.Transaction;

public record TransactionRequest(
    string AccountNumber,
    decimal Amount
);