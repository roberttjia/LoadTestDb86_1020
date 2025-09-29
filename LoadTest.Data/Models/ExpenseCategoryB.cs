using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class ExpenseCategoryB
    {
        public ExpenseCategoryB()
        {
            Expense = new HashSet<ExpenseB>();
        }

        public int ExpenseCategoryBId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<ExpenseB> Expense { get; set; }
    }
}
