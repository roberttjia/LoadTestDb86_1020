using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class SellingListB
    {
        public SellingListB()
        {
            ProductStock = new HashSet<ProductStockB>();
        }

        public int SellingListBId { get; set; }
        public int SellingBId { get; set; }
        public int ProductBId { get; set; }
        public decimal SellingPrice { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Warranty { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        
        public virtual SellingB Selling { get; set; } = null!;
        public virtual ProductB Product { get; set; } = null!;
        public virtual ICollection<ProductStockB> ProductStock { get; set; }
    }
}
