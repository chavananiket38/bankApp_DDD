namespace BankApp.Application.Services.Accounts;

public interface IAccountService {
    AccountResult GetAccountDetails(string accountNumber);
}