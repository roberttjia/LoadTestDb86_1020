using System;

namespace LoadTest.Data.Models
{
    public class ExpenseFixedB
    {
        public int ExpenseFixedBId { get; set; }
        public string ExpenseName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
