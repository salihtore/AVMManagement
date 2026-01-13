using System;
using System.ComponentModel.DataAnnotations;

namespace AVM.Core.Entities
{
    public class ServiceRequest
    {
        [Key]
        public int RequestId { get; set; }
        public int StoreId { get; set; }
        public string RequestType { get; set; } // 'Elektrik', 'Mekanik', etc.
        public string Description { get; set; }
        public string Status { get; set; } // 'Pending', 'Resolved'
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ResolvedAt { get; set; }
    }
}
