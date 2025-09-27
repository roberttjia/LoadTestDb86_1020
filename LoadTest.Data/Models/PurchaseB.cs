using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class PurchaseB
    {
        public PurchaseB()
        {
            PurchaseList = new HashSet<PurchaseListB>();
            PurchasePaymentList = new HashSet<PurchasePaymentListB>();
            ProductLog = new HashSet<ProductLogB>();
            PurchasePaymentReturnRecord = new HashSet<PurchasePaymentReturnRecordB>();
        }

        public int PurchaseBId { get; set; }
        public int RegistrationBId { get; set; }
        public int VendorBId { get; set; }
        public int PurchaseSn { get; set; }
        public decimal PurchaseTotalPrice { get; set; }
        public decimal PurchaseDiscountAmount { get; set; }
        public decimal PurchaseDiscountPercentage { get; set; }
        public decimal PurchasePaidAmount { get; set; }
        public decimal PurchaseReturnAmount { get; set; }
        public decimal PurchaseDueAmount { get; set; }
        public string PurchasePaymentStatus { get; set; } = string.Empty;
        public string MemoNumber { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual RegistrationB Registration { get; set; } = null!;
        public virtual VendorB Vendor { get; set; } = null!;
        public virtual SellingB? Selling { get; set; }
        public virtual ICollection<PurchaseListB> PurchaseList { get; set; }
        public virtual ICollection<PurchasePaymentListB> PurchasePaymentList { get; set; }
        public virtual ICollection<ProductLogB> ProductLog { get; set; }
        public virtual ICollection<PurchasePaymentReturnRecordB> PurchasePaymentReturnRecord { get; set; }
    }
}
