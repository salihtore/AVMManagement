using System;

namespace AVM.Core.Entities
{
    public class StoreEmployee
    {
        public int StoreEmployeeId { get; set; }
        public int StoreId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
