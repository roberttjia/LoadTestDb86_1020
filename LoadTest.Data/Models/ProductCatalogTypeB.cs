using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class ProductCatalogTypeB
    {
        public ProductCatalogTypeB()
        {
            ProductCatalog = new HashSet<ProductCatalogB>();
        }

        public int ProductCatalogTypeBId { get; set; }
        public string ProductCatalogTypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public virtual ICollection<ProductCatalogB> ProductCatalog { get; set; }
    }
}
