using Microsoft.EntityFrameworkCore;
using BankApp.Domain.Entities;

namespace BankApp.Infrastructure.Persistence;

public class BankAppDbContext : DbContext{
    public BankAppDbContext(DbContextOptions<BankAppDbContext> options): base(options){
    } 

    public DbSet<Account> Accounts {get; set;} = null!;

}