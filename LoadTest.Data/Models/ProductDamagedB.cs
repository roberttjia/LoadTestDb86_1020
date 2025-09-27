using System;

namespace LoadTest.Data.Models
{
    public class ProductDamagedB
    {
        public int ProductDamagedBId { get; set; }
        public int ProductStockBId { get; set; }
        public string DamageType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DamageDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual ProductStockB ProductStock { get; set; } = null!;
    }
}
