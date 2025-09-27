using System;

namespace LoadTest.Data.Models
{
    public class AccountWithdrawB
    {
        public int AccountWithdrawBId { get; set; }
        public int AccountBId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime WithdrawDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string TransactionReference { get; set; } = string.Empty;

        public virtual AccountB Account { get; set; } = null!;
    }
}
