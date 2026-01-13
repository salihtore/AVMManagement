using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AVM.Core.Entities
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveId { get; set; }
        public int EmployeeId { get; set; }
        
        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string LeaveType { get; set; } // 'Annual', 'Sick'
        public string Reason { get; set; }
        public string RejectionReason { get; set; } // New field for rejection explanation
        public string Status { get; set; } // 'Pending', 'Approved', 'Rejected'
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
