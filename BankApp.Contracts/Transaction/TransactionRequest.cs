namespace BankApp.Contracts.Transaction;

public record WithdrawalTransactionRequest(
    string AccountNumber,
    string Password,
    decimal Amount
);
public record DepositTransactionRequest(
    string AccountNumber,
    decimal Amount
);
public record FundTransferTransactionRequest(
    string SourceAccountNumber,
    string DestinationAccountNumber,
    string SourceAccountPassword,
    decimal Amount
);