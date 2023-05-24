using BankApp.Application.Services.Accounts;
using BankApp.Application.Services.Authentication;
using BankApp.Application.Services.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService> ();
        services.AddScoped<ITransactionService, TransactionService> ();
        services.AddScoped<IAccountService, AccountService> ();
        return services;
    }
}