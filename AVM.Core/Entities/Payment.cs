using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM.Core.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int? RentId { get; set; }
        public int TenantId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public string Description { get; set; }
        public DateTime PaidAt { get; set; }
    }
}
