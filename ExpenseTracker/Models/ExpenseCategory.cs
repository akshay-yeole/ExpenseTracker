using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class ExpenseCategory
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
