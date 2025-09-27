using System;

namespace LoadTest.Data.Models
{
    public class ProductLogB
    {
        public int ProductLogBId { get; set; }
        public int ProductStockBId { get; set; }
        public int? PurchaseId { get; set; }
        public int? SellingId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime LogDate { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public virtual ProductStockB ProductStock { get; set; } = null!;
        public virtual PurchaseB? Purchase { get; set; }
        public virtual SellingB? Selling { get; set; }
    }
}
