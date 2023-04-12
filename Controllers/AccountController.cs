using AccountsWebApi.Models;
using AccountsWebApi.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AccountsWebApi.Controllers
{

    [ApiController]
    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly AccountdbContext _context;

        public AccountController(AccountdbContext context) 
        {
            _context = context;
        
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            var accounts = _context.Accounts.ToList();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccount), new { id = account.AccountId }, account);
        }

        [HttpDelete("delete/{accountId}")]

        public async Task<ActionResult> Delete(int accountId)
        {
            var affectedRows = await _context.Accounts.Where(a => a.AccountId == accountId).ExecuteDeleteAsync();
            if(affectedRows == 0) 
            {
                return NotFound();
            }
           
            return NoContent();
        }


        [HttpPut]
        public ActionResult<Account> Update([FromBody] Account account)
        {
            _context.Update(account);
            _context.SaveChanges();

            return Ok(account);
        }

    }
}
