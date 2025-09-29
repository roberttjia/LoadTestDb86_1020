using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class SellingPaymentB
    {
        public SellingPaymentB()
        {
            SellingPaymentList = new HashSet<SellingPaymentListB>();
        }

        public int SellingPaymentBId { get; set; }
        public int CustomerBId { get; set; }
        public int? AccountId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public decimal ServiceCharge { get; set; }
        public string Receipt { get; set; } = string.Empty;
        public string BankName { get; set; } = string.Empty;
        public string CheckNumber { get; set; } = string.Empty;

        public virtual CustomerB Customer { get; set; } = null!;
        public virtual AccountB? Account { get; set; }
        public virtual ICollection<SellingPaymentListB> SellingPaymentList { get; set; }
    }
}
