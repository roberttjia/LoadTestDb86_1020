using System;

namespace LoadTest.Data.Models
{
    public class ExpenseTransportationListB
    {
        public int ExpenseTransportationListBId { get; set; }
        public int ExpenseTransportationBId { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual ExpenseTransportationB ExpenseTransportation { get; set; } = null!;
    }
}
