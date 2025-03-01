using ExpenseTracker.Contracts;
using ExpenseTracker.Core.AppExceptions.ExceptionModels;
using ExpenseTracker.ExpenseDataContext;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly ExpenseContext _context;

        public ExpenseService(ExpenseContext context)
        {
            _context = context;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            var account = await _context.Accounts.FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundException("Account not found");
            }
            account.Balance -= expense.Amount;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            var expenses = await _context.Expenses.ToListAsync();
            if (expenses == null || expenses.Count == 0)
            {
                throw new NotFoundException("No Expense Found");
            }
            return expenses;
        }
    }
}
