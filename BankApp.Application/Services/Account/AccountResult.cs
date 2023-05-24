namespace BankApp.Application.Services.Accounts;

public record AccountResult(
    string AccountNumber,
    string FirstName,
    string LastName,
    string Email,
    string Gender,
    string City,
    decimal AccountBalance
);