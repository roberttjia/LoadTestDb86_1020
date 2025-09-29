using System;

namespace LoadTest.Data.Models
{
    public class AdminMoneyCollectionB
    {
        public int AdminMoneyCollectionBId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CollectionDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string CollectedBy { get; set; } = string.Empty;
    }
}
