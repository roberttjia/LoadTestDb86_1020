using System;

namespace LoadTest.Data.Models
{
    public class PurchasePaymentListB
    {
        public int PurchasePaymentListBId { get; set; }
        public int PurchasePaymentBId { get; set; }
        public int PurchaseBId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }

        public virtual PurchasePaymentB PurchasePayment { get; set; } = null!;
        public virtual PurchaseB Purchase { get; set; } = null!;
    }
}
