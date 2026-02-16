using CGR.Application.DTOs;
using CGR.Application.Interfaces;
using CGR.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CGR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDTO>>> GetTransactions()
        {
            var transactions = await _transactionService.GetTransactionsAsync();
            if (transactions == null)
            {
                return NotFound("No transactions found.");
            }
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] CreateTransactionDTO transactionDTO)
        {
            if (transactionDTO == null)
            {
                return BadRequest("Transaction data is required.");
            }

            await _transactionService.CreateAsync(transactionDTO);
            return NoContent();
        }
    }
}
