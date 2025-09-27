using System;

namespace LoadTest.Data.Models
{
    public class ServiceListB
    {
        public int ServiceListBId { get; set; }
        public int ServiceBId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual ServiceB Service { get; set; } = null!;
    }
}
