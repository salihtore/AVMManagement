using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM.Core.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int? UserId { get; set; } // Link to User login
        public int? StoreId { get; set; } // Assigned Store (Nullable for general staff)
        public string FullName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        
        // New Fields
        public DateTime StartDate { get; set; }
        public string ShiftStart { get; set; } // e.g. "09:00"
        public string ShiftEnd { get; set; }   // e.g. "18:00"
        public int WorkedDays { get; set; }
    }
}
