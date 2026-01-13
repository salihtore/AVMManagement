using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM.Core.Entities
{
    public class CommonExpense
    {
        public int CommonExpenseId { get; set; }
        public int ExpenseId { get; set; }
        public int TenantId { get; set; }
        public decimal ShareAmount { get; set; }
    }
}
