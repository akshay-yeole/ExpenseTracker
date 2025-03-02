using ExpenseTracker.Contracts;
using ExpenseTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpensesController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("GetAllExpenses")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseService.GetAllExpensesAsync();
            return Ok(expenses);
        }

        [HttpPost("AddExpense")]
        public async Task<IActionResult> AddExpense([FromBody] Expense expense)
        {
            await _expenseService.AddExpenseAsync(expense);
            return Ok();
        }
    }
}
