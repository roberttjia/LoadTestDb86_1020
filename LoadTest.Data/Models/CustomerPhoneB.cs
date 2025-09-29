using System;

namespace LoadTest.Data.Models
{
    public class CustomerPhoneB
    {
        public int CustomerPhoneBId { get; set; }
        public int CustomerBId { get; set; }
        public string Phone { get; set; } = string.Empty;
        public bool? IsPrimary { get; set; }
        public DateTime InsertDate { get; set; }
        
        public virtual CustomerB Customer { get; set; } = null!;
    }
}
