using System;

namespace LoadTest.Data.Models
{
    public class SellingPaymentListB
    {
        public int SellingPaymentListBId { get; set; }
        public int SellingPaymentBId { get; set; }
        public int SellingBId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual SellingPaymentB SellingPayment { get; set; } = null!;
        public virtual SellingB Selling { get; set; } = null!;
    }
}
