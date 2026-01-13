using System;

namespace AVM.Core.Entities
{
    public class Turnover
    {
        public int TurnoverId { get; set; }
        public int StoreId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation Property - assumes Store entity exists
        // public virtual Store Store { get; set; } 
    }
}
