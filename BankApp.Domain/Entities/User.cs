using BankApp.Domain.Common;

namespace BankApp.Domain.Entities;

public class Account {

    public Guid Id { get; set; } = Guid.NewGuid();
    public string AccountNumber {get; set;} = Generator.GetRandomNumbers(8);
    public string FirstName {get; set;}  = null!;
    public string LastName {get; set;} = null!;
    public string Email {get; set;} = null!;
    public string Password {get; set;} = null!;
    public string Gender {get; set;} = null!;
    public string City {get; set;} = null!;
    public decimal AccountBalance {get; set;} = decimal.Zero;
    public long AccountLimit {get; set;} 
}