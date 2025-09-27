using System;

namespace LoadTest.Data.Models
{
    public class AccountDepositB
    {
        public int AccountDepositBId { get; set; }
        public int AccountBId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DepositDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string TransactionReference { get; set; } = string.Empty;

        public virtual AccountB Account { get; set; } = null!;
    }
}
