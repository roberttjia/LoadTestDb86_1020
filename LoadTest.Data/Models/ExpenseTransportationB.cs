﻿using System;
using System.Collections.Generic;

namespace LoadTest.Data.Models
{
    public class ExpenseTransportationB
    {
        public ExpenseTransportationB()
        {
            ExpenseTransportationList = new HashSet<ExpenseTransportationListB>();
        }

        public int ExpenseTransportationBId { get; set; }
        public int CustomerBId { get; set; }
        public int? AccountId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime TransportationDate { get; set; }
        public DateTime InsertDate { get; set; }
        public string VehicleType { get; set; } = string.Empty;
        public string Route { get; set; } = string.Empty;
        public decimal Distance { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        public virtual CustomerB Customer { get; set; } = null!;
        public virtual AccountB? Account { get; set; }
        public virtual ICollection<ExpenseTransportationListB> ExpenseTransportationList { get; set; }
    }
}
