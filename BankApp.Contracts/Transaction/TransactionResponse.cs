
namespace BankApp.Contracts.Transaction;

public record TransactionResponse(
    string AccountNumber,
    string FirstName,
    string LastName,
    string Email,
    decimal AccountBalance
);
public record FundTransferResponse(
    string SourceAccountNumber,
    decimal SourceAccountBalance,
    
    string DestinationAccountNumber,
    decimal DestinationAccountBalance
);