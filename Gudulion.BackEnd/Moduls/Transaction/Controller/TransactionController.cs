using Gudulion.BackEnd.DB;
using Gudulion.BackEnd.Moduls.Transaction.DTO;
using Gudulion.BackEnd.Moduls.Transaction.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gudulion.BackEnd.Moduls.Transaction.Controller;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(Roles = "GroupAdmin")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public IActionResult Create([FromBody] AddTransactionDto dto)
    {
        var transaction = _transactionService.Create(dto);
        return Ok(transaction);
    }

    [HttpPut]
    public IActionResult ChangeStatus([FromBody] ChangeTransactionStatusDto dto)
    {
        _transactionService.ChangeTransactionStatus(dto);
        return Ok();
    }

    [HttpGet]
    public IActionResult GetByTripId([FromQuery] int tripId)
    {
        var transactions = _transactionService.GetTransactionByTripId(tripId);
        return Ok(transactions);
    }
}