using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class AccountB
    {
        public AccountB()
        {
            AccountDeposit = new HashSet<AccountDepositB>();
            AccountWithdraw = new HashSet<AccountWithdrawB>();
            SellingPayment = new HashSet<SellingPaymentB>();
            PurchasePayment = new HashSet<PurchasePaymentB>();
            Expense = new HashSet<ExpenseB>();
            ExpenseTransportation = new HashSet<ExpenseTransportationB>();
            SellingPaymentReturnRecord = new HashSet<SellingPaymentReturnRecordB>();
            PurchasePaymentReturnRecord = new HashSet<PurchasePaymentReturnRecordB>();
            SellingExpense = new HashSet<SellingExpenseB>();
        }
        
        public int AccountBId { get; set; }
        public string AccountName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public decimal CostPercentage { get; set; }
        
        public virtual InstitutionB? Institution { get; set; }
        public virtual ICollection<AccountWithdrawB> AccountWithdraw { get; set; }
        public virtual ICollection<AccountDepositB> AccountDeposit { get; set; }
        public virtual ICollection<SellingPaymentB> SellingPayment { get; set; }
        public virtual ICollection<PurchasePaymentB> PurchasePayment { get; set; }
        public virtual ICollection<ExpenseB> Expense { get; set; }
        public virtual ICollection<ExpenseTransportationB> ExpenseTransportation { get; set; }
        public virtual ICollection<SellingPaymentReturnRecordB> SellingPaymentReturnRecord { get; set; }
        public virtual ICollection<SellingExpenseB> SellingExpense { get; set; }
        public virtual ICollection<PurchasePaymentReturnRecordB> PurchasePaymentReturnRecord { get; set; }
    }
}
