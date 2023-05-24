namespace BankApp.Contracts.Accounts;

public record AccountDetailsResponse(
    string AccountNumber,
    string FirstName,
    string LastName,
    string Email,
    string Gender,
    string City,
    decimal AccountBalance
);
