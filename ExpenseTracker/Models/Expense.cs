using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ExpenseName { get; set; } = string.Empty;

        [Required]
        public double Amount { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
