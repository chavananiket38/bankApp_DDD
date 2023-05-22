namespace BankApp.Application.Services.Transaction;

public record TransactionResult(
    string AccountNumber,
    string FirstName,
    string LastName,
    string Email,
    decimal AccountBalance
);

public record FundTransferResult(
    string SourceAccountNumber,
    decimal SourceAccountBalance,
    
    string DestinationAccountNumber,
    decimal DestinationAccountBalance

);