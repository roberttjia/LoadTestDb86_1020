using System;

namespace LoadTest.Data.Models
{
    public class SellingAdjustmentB
    {
        public int SellingAdjustmentBId { get; set; }
        public int SellingBId { get; set; }
        public int ProductBId { get; set; }
        public int ProductStockBId { get; set; }
        public string AdjustmentType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime AdjustmentDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string ApprovedBy { get; set; } = string.Empty;

        public virtual SellingB Selling { get; set; } = null!;
        public virtual ProductB Product { get; set; } = null!;
        public virtual ProductStockB ProductStock { get; set; } = null!;
    }
}
