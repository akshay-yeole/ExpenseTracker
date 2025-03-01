using ExpenseTracker.Contracts;
using ExpenseTracker.Core.AppExceptions.ExceptionModels;
using ExpenseTracker.ExpenseDataContext;
using ExpenseTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Services
{
    public class AccountService : IAccountService
    {
        private readonly ExpenseContext _context;

        public AccountService(ExpenseContext context)
        {
            _context = context;
        }

        public async Task<Account> GetAccount()
        {
            var account = await _context.Accounts.FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundException("No Account Found");
            }
            return account;
        }

        public async Task UpsertAsync(Account account)
        {
            var existingAccount = await _context.Accounts.FirstOrDefaultAsync();
            if (existingAccount == null)
            {
                await _context.Accounts.AddAsync(account);
            }
            else
            {
                existingAccount.Balance += account.Balance;
            }
            await _context.SaveChangesAsync();
        }
    }
}
