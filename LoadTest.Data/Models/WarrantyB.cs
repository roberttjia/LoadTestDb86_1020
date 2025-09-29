using System;

namespace LoadTest.Data.Models
{
    public class WarrantyB
    {
        public int WarrantyBId { get; set; }
        public int SellingBId { get; set; }
        public int ProductStockBId { get; set; }
        public string WarrantyType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Terms { get; set; } = string.Empty;
        public string Coverage { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public DateTime InsertDate { get; set; }
        public string ContactInfo { get; set; } = string.Empty;
        public decimal WarrantyAmount { get; set; }
        public string Status { get; set; } = string.Empty;

        public virtual SellingB Selling { get; set; } = null!;
        public virtual ProductStockB ProductStock { get; set; } = null!;
    }
}
