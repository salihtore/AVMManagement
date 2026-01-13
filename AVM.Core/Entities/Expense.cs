using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM.Core.Entities
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        
        // Navigation Property - Opsiyonel, eğer EF Lazy Loading kullanacaksak virtual yaparız
        // Şimdilik basit tutalım.
    }
}
