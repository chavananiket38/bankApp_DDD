namespace BankApp.Application.Services.Authentication;

public interface IAuthenticationService{
    AuthenticationResult Login(string email, string password);
    AuthenticationResult Register(string firstName, string lastName, string email, string password, string gender, string city, long accountlimit);
}