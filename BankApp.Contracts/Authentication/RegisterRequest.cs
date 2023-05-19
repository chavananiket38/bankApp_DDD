namespace BankApp.Contracts.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string Gender,
    string City ,
    long AccountLimit 
);