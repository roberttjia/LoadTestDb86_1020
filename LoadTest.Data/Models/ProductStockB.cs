using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class ProductStockB
    {
        public ProductStockB()
        {
            SellingAdjustment = new HashSet<SellingAdjustmentB>();
            ProductLog = new HashSet<ProductLogB>();
            Warranty = new HashSet<WarrantyB>();
        }

        public int ProductStockBId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public int ProductBId { get; set; }
        public int? SellingListId { get; set; }
        public int PurchaseListBId { get; set; }
        public bool IsSold { get; set; }
        
        public virtual ProductB Product { get; set; } = null!;
        public virtual SellingListB? SellingList { get; set; }
        public virtual PurchaseListB PurchaseList { get; set; } = null!;
        public virtual ProductDamagedB? ProductDamaged { get; set; }
        public virtual ICollection<SellingAdjustmentB> SellingAdjustment { get; set; }
        public virtual ICollection<ProductLogB> ProductLog { get; set; }
        public virtual ICollection<WarrantyB> Warranty { get; set; }
    }
}
