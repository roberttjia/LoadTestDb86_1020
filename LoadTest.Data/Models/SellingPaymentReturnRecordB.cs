using System;

namespace LoadTest.Data.Models
{
    public class SellingPaymentReturnRecordB
    {
        public int SellingPaymentReturnRecordBId { get; set; }
        public int SellingBId { get; set; }
        public int? AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime ReturnDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string ApprovedBy { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public string TransactionId { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public virtual SellingB Selling { get; set; } = null!;
        public virtual AccountB? Account { get; set; }
    }
}
