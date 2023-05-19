using BankApp.Application.Common.Interfaces.Authentication;
using BankApp.Application.Common.Interfaces.Persistence;
using BankApp.Application.Services.Authentication;
using BankApp.Infrastructure.Authentication;
using BankApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService> ();
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator> ();
        services.AddScoped<IAccountRepository, AccountRepository> ();

        
        return services;
    }
    public static IServiceCollection AddDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BankAppDbContext>(options => {
            options.UseSqlServer(connectionString);
        });

        return services;
    }
}