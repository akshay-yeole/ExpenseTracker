using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public double Balance { get; set; }
    }
}
