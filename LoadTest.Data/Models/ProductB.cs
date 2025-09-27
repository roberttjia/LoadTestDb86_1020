using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class ProductB
    {
        public ProductB()
        {
            ProductStock = new HashSet<ProductStockB>();
            SellingAdjustment = new HashSet<SellingAdjustmentB>();
            PurchaseList = new HashSet<PurchaseListB>();
            SellingList = new HashSet<SellingListB>();
        }

        public int ProductBId { get; set; }
        public int ProductCatalogBId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public DateTime InsertDate { get; set; }
        
        public virtual ProductCatalogB ProductCatalog { get; set; } = null!;
        public virtual ICollection<ProductStockB> ProductStock { get; set; }
        public virtual ICollection<SellingAdjustmentB> SellingAdjustment { get; set; }
        public virtual ICollection<PurchaseListB> PurchaseList { get; set; }
        public virtual ICollection<SellingListB> SellingList { get; set; }
    }
}
