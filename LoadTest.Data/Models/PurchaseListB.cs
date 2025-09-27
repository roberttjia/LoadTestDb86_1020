using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class PurchaseListB
    {
        public PurchaseListB()
        {
            ProductStock = new HashSet<ProductStockB>();
        }
        
        public int PurchaseListBId { get; set; }
        public int PurchaseBId { get; set; }
        public int ProductBId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public decimal SellingPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        
        public virtual PurchaseB Purchase { get; set; } = null!;
        public virtual ProductB Product { get; set; } = null!;
        public virtual ICollection<ProductStockB> ProductStock { get; set; }
    }
}
