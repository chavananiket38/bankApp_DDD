using Microsoft.AspNetCore.Mvc;
using BankApp.Contracts.Authentication;
using BankApp.Application.Services.Authentication;

namespace BankApp.Api.Controllers;

[ApiController]

[Route("auth")]
public class AuthenticationController : ControllerBase{

    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService){
        _authenticationService = authenticationService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request){
        var authResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password,
            request.Gender,
            request.City,
            request.AccountLimit
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.AccountNumber,
            authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request){
        var authResult = _authenticationService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.AccountNumber,
            authResult.Token
        );
        return Ok(response);
    }

}