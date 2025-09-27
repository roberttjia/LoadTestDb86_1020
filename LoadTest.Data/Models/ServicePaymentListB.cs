using System;

namespace LoadTest.Data.Models
{
    public class ServicePaymentListB
    {
        public int ServicePaymentListBId { get; set; }
        public int ServiceBId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime PaymentDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual ServiceB Service { get; set; } = null!;
    }
}
