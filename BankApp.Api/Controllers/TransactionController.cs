using BankApp.Contracts.Transaction;
using BankApp.Application.Services.Transaction;
using Microsoft.AspNetCore.Mvc;
namespace BankApp.Api.Controllers;

[ApiController]

[Route("transaction")]
public class TransactionController : ControllerBase{

    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService){
        _transactionService = transactionService;
    }

    [HttpPost("withdrawal")]
    public IActionResult Withdrawal(TransactionRequest request){
        var transactionResult = _transactionService.Withdrawal(
            request.AccountNumber,
            request.Amount
        );

        var response = new TransactionResponse(
            transactionResult.AccountNumber,
            transactionResult.FirstName,
            transactionResult.LastName,
            transactionResult.Email,
            transactionResult.AccountBalance
        );

        return Ok(response);
    }

    [HttpPost("deposit")]
    public IActionResult deposit(TransactionRequest request){
        var transactionResult = _transactionService.Deposit(
            request.AccountNumber,
            request.Amount
        );

        var response = new TransactionResponse(
            transactionResult.AccountNumber,
            transactionResult.FirstName,
            transactionResult.LastName,
            transactionResult.Email,
            transactionResult.AccountBalance
        );

        return Ok(response);
    }

}