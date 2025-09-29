using System;

namespace LoadTest.Data.Models
{
    public class SellingPromiseDateMissB
    {
        public int SellingPromiseDateMissBId { get; set; }
        public int SellingBId { get; set; }
        public DateTime PromisedDate { get; set; }
        public DateTime ActualDate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public string Notes { get; set; } = string.Empty;

        public virtual SellingB Selling { get; set; } = null!;
    }
}
