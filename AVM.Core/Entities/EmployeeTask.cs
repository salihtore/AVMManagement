using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace AVM.Core.Entities
{
    // Named 'EmployeeTask' to avoid conflict with System.Threading.Tasks.Task
    // Map to 'Tasks' table in Context
    [Table("Tasks")]
    public class EmployeeTask
    {
        [Key]
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime AssignedAt { get; set; } = DateTime.Now;
        public DateTime? CompletedAt { get; set; }
    }
}
