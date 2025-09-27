using System;

namespace LoadTest.Data.Models
{
    public class SellingExpenseB
    {
        public int SellingExpenseBId { get; set; }
        public int SellingBId { get; set; }
        public decimal Expense { get; set; }
        public string ExpenseDescription { get; set; } = string.Empty;
        public DateTime InsertDateUtc { get; set; }
        public int? AccountId { get; set; }

        public virtual SellingB Selling { get; set; } = null!;
        public virtual AccountB? Account { get; set; }
    }
}
