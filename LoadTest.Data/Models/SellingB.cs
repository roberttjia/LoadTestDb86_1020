using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class SellingB
    {
        public SellingB()
        {
            SellingAdjustment = new HashSet<SellingAdjustmentB>();
            SellingList = new HashSet<SellingListB>();
            SellingPaymentList = new HashSet<SellingPaymentListB>();
            SellingExpense = new HashSet<SellingExpenseB>();
            Warranty = new HashSet<WarrantyB>();
            ProductLog = new HashSet<ProductLogB>();
            SellingPromiseDateMisses = new HashSet<SellingPromiseDateMissB>();
            SellingPaymentReturnRecord = new HashSet<SellingPaymentReturnRecordB>();
        }

        public int SellingBId { get; set; }
        public int RegistrationBId { get; set; }
        public int CustomerBId { get; set; }
        public int SellingSn { get; set; }
        public decimal SellingTotalPrice { get; set; }
        public decimal SellingDiscountAmount { get; set; }
        public decimal SellingDiscountPercentage { get; set; }
        public decimal SellingPaidAmount { get; set; }
        public decimal SellingReturnAmount { get; set; }
        public decimal SellingDueAmount { get; set; }
        public string SellingPaymentStatus { get; set; } = string.Empty;
        public DateTime SellingDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime? PromisedPaymentDate { get; set; }
        public string SellingNotes { get; set; } = string.Empty;
        public decimal ServiceCharge { get; set; }
        public decimal ServiceCost { get; set; }
        public string ServiceChargeDescription { get; set; } = string.Empty;
        public decimal ExpenseTotal { get; set; }
        public decimal AccountTransactionCharge { get; set; }
        public decimal BuyingTotalPrice { get; set; }
        public decimal SellingAccountCost { get; set; }
        public decimal ServiceProfit { get; set; }
        public decimal SellingProfit { get; set; }
        public decimal SellingNetProfit { get; set; }
        public decimal GrandProfit { get; set; }
        public decimal PurchaseAdjustedAmount { get; set; }
        public string PurchaseDescription { get; set; } = string.Empty;
        public int? PurchaseId { get; set; }

        public virtual CustomerB Customer { get; set; } = null!;
        public virtual RegistrationB Registration { get; set; } = null!;
        public virtual PurchaseB? Purchase { get; set; }
        public virtual ICollection<SellingAdjustmentB> SellingAdjustment { get; set; }
        public virtual ICollection<SellingListB> SellingList { get; set; }
        public virtual ICollection<SellingPaymentListB> SellingPaymentList { get; set; }
        public virtual ICollection<SellingExpenseB> SellingExpense { get; set; }
        public virtual ICollection<WarrantyB> Warranty { get; set; }
        public virtual ICollection<ProductLogB> ProductLog { get; set; }
        public virtual ICollection<SellingPromiseDateMissB> SellingPromiseDateMisses { get; set; }
        public virtual ICollection<SellingPaymentReturnRecordB> SellingPaymentReturnRecord { get; set; }
    }
}
