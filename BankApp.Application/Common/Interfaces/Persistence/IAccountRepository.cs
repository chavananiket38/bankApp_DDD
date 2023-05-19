using BankApp.Domain.Entities;

namespace BankApp.Application.Common.Interfaces.Persistence;

public interface IAccountRepository{
    Account? GetAccountByEmail(string email);

    void Add(Account account);

    Account? GetAccountByAccountNumber(string accountNumber);
    public void UpdateAccount(Account account);
}