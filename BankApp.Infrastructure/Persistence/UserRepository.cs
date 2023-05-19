using BankApp.Application.Common.Interfaces.Persistence;
using BankApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Infrastructure.Persistence;

public class AccountRepository : IAccountRepository
{
    private readonly BankAppDbContext _dbContext;
    public AccountRepository(BankAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Account account)
    {
        _dbContext.Add(account);
        _dbContext.SaveChanges();
    }

    public Account? GetAccountByEmail(string email)
    {
        return _dbContext.Accounts.SingleOrDefault(u => u.Email == email);
    }

    public Account? GetAccountByAccountNumber(string accountNumber){
        return _dbContext.Accounts.SingleOrDefault(u => u.AccountNumber == accountNumber);
    }

    public void UpdateAccount(Account account){
        _dbContext.Accounts.Entry(account).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }
}
