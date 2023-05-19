using BankApp.Application.Common.Interfaces.Authentication;
using BankApp.Application.Common.Interfaces.Persistence;
using BankApp.Domain.Entities;

namespace BankApp.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService{

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IAccountRepository _accountRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IAccountRepository accountRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _accountRepository = accountRepository;
    }

    public AuthenticationResult Login(string email, string password){
        var account = _accountRepository.GetAccountByEmail(email);
        if(account is null){
            throw new Exception("Account with given email does not exist");
        }

        if(account.Password != password){
            throw new Exception("Invalid Password");
        }

        var token = _jwtTokenGenerator.GenerateToken(account.Id, account.FirstName, account.LastName);

        return new AuthenticationResult(
            account.Id,
            account.FirstName,
            account.LastName,
            email,
            account.AccountNumber,
            token
        );
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password, string gender, string city, long accountlimit){
        
        if(_accountRepository.GetAccountByEmail(email) is not null){
            throw new Exception("Account already exist");
        }
        
        var account = new Account
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
            Gender = gender,
            City = city,
            AccountLimit = accountlimit
        };

        _accountRepository.Add(account);

        var token = _jwtTokenGenerator.GenerateToken(account.Id, firstName, lastName);

        return new AuthenticationResult(
            account.Id,
            firstName,
            lastName,
            email,
            "123",
            token
        );
    }

}