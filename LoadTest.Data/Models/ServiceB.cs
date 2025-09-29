using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public partial class ServiceB
    {
        public ServiceB()
        {
            ServiceList = new HashSet<ServiceListB>();
            ServicePaymentList = new HashSet<ServicePaymentListB>();
        }

        public int ServiceBId { get; set; }
        public int RegistrationBId { get; set; }
        public int CustomerBId { get; set; }
        public int ServiceSn { get; set; }
        public decimal ServiceTotalPrice { get; set; }
        public decimal ServiceDiscountAmount { get; set; }
        public decimal ServiceDiscountPercentage { get; set; }
        public decimal ServicePaidAmount { get; set; }
        public decimal ServiceDueAmount { get; set; }
        public string ServicePaymentStatus { get; set; } = string.Empty;
        public DateTime ServiceDate { get; set; }
        public DateTime InsertDate { get; set; }

        public virtual CustomerB Customer { get; set; } = null!;
        public virtual RegistrationB Registration { get; set; } = null!;
        public virtual ICollection<ServiceListB> ServiceList { get; set; }
        public virtual ICollection<ServicePaymentListB> ServicePaymentList { get; set; }
    }
}
