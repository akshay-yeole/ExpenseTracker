using ExpenseTracker.Models;

namespace ExpenseTracker.Contracts
{
    public interface IExpenseService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task AddExpenseAsync(Expense expense);
    }
}
