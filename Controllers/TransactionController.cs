using AccountsWebApi.DataModel;
using AccountsWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;

namespace AccountsWebApi.Controllers

{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly AccountdbContext _context;

        public TransactionController(AccountdbContext context)
        {
            _context = context;
        }



        [HttpGet("balance/{id}")]
        public ActionResult<Transaction> GetTransaction(int id)
        {


            decimal amount = 0;

            var deposits = _context.Transactions.Where(t => t.AccountId == id && t.TransactionType == TransactionType.Deposit)
                                                .Sum(t => t.Amount);

            var withdrawals = _context.Transactions.Where(t => t.AccountId == id && t.TransactionType == TransactionType.Withdrawal)
                                                   .Sum(t => t.Amount);
            amount += amount + deposits - withdrawals;

            if (deposits >= 0 || withdrawals >= 0)
            {
                var responseJson = new
                {
                    balance = amount

                };
                string json = JsonConvert.SerializeObject(responseJson);

                return Ok(json);
            }
            return NoContent();


        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Account>> GetAccounts(int id)
        {
            var transactions = _context.Transactions.Where(t=> t.AccountId == id)
                                                    .ToList();
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId }, transaction);
        }


    }
}
