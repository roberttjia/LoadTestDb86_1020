using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PurchasePaymentB
    {
        public PurchasePaymentB()
        {
            PurchasePaymentList = new HashSet<PurchasePaymentListB>();
        }

        public int PurchasePaymentBId { get; set; }
        public int VendorBId { get; set; }
        public int? AccountId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public bool IsVerified { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;

        public virtual VendorB Vendor { get; set; } = null!;
        public virtual AccountB? Account { get; set; }
        public virtual ICollection<PurchasePaymentListB> PurchasePaymentList { get; set; }
    }
}
