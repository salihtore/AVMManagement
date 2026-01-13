using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM.Core.Entities
{
    public class Rent
    {
        public int RentId { get; set; }
        public int ContractId { get; set; }
        public DateTime RentMonth { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidAt { get; set; }
        public decimal LateFee { get; set; }
    }
}
