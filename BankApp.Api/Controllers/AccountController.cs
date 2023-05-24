using Microsoft.AspNetCore.Mvc;
using BankApp.Contracts.Accounts;
using BankApp.Application.Services.Accounts;

namespace BankApp.Api.Controllers;


[ApiController]

[Route("account")]
public class AccountController : ControllerBase{

    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("details")]
    public IActionResult getDetails(AccountDetailsRequest request){
        var account = _accountService.GetAccountDetails(request.AccountNumber);

        var response = new AccountDetailsResponse(
            account.AccountNumber,
            account.FirstName,
            account.LastName,
            account.Email,
            account.Gender,
            account.City,
            account.AccountBalance
        );

        return Ok(response);
    }
}