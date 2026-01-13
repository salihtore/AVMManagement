using System;

namespace AVM.Core.Entities
{
    public class Shift
    {
        public int ShiftId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Note { get; set; }
    }
}
