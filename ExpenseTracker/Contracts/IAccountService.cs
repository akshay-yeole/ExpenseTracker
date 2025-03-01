using ExpenseTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Contracts
{
    public interface IAccountService
    {
       Task<Account> GetAccount();

        Task UpsertAsync(Account account);
    }
}
