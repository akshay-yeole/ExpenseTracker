using ExpenseTracker.Contracts;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("CurrentBalance")]
        public async Task<IActionResult> GetAccount()
        {
            var account = await _accountService.GetAccount();
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpPost("UpsertBalance")]
        public async Task<IActionResult> Upsert(Account account)
        {
            await _accountService.UpsertAsync(account);
            return NoContent();
        }
    }
}
