using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class CustomerB
    {
        public CustomerB()
        {
            Selling = new HashSet<SellingB>();
            SellingPayment = new HashSet<SellingPaymentB>();
            Service = new HashSet<ServiceB>();
            ServiceDevice = new HashSet<ServiceDeviceB>();
            ExpenseTransportation = new HashSet<ExpenseTransportationB>();
            CustomerPhone = new HashSet<CustomerPhoneB>();
        }

        public int CustomerBId { get; set; }
        public string OrganizationName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal ReturnAmount { get; set; }
        public decimal Paid { get; set; }
        public decimal AccountTransactionCharge { get; set; }
        public decimal Due { get; set; }
        public decimal PurchaseAdjustedAmount { get; set; }
        public decimal DueLimit { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime InsertDate { get; set; }
        public string Designation { get; set; } = string.Empty;
        public bool IsIndividual { get; set; }
        
        public virtual ICollection<SellingB> Selling { get; set; }
        public virtual ICollection<SellingPaymentB> SellingPayment { get; set; }
        public virtual ICollection<ServiceB> Service { get; set; }
        public virtual ICollection<ServiceDeviceB> ServiceDevice { get; set; }
        public virtual ICollection<CustomerPhoneB> CustomerPhone { get; set; }
        public virtual ICollection<ExpenseTransportationB> ExpenseTransportation { get; set; }
    }
}
