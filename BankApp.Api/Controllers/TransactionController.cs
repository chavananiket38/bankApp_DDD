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

    [HttpPut("withdrawal")]
    public IActionResult Withdrawal(WithdrawalTransactionRequest request){
        var transactionResult = _transactionService.Withdrawal(
            request.AccountNumber,
            request.Password,
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

    [HttpPut("deposit")]
    public IActionResult deposit(DepositTransactionRequest request){
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

    [HttpPut("fundTransfer")]
    public IActionResult FundTransfer(FundTransferTransactionRequest request){
        var transactionResult = _transactionService.FundTransfer(
            request.SourceAccountNumber,
            request.DestinationAccountNumber,
            request.SourceAccountPassword,
            request.Amount
        );

        var response = new FundTransferResponse(
            transactionResult.SourceAccountNumber,
            transactionResult.SourceAccountBalance,
            transactionResult.DestinationAccountNumber,
            transactionResult.DestinationAccountBalance
        );

        return Ok(response);
    }

}