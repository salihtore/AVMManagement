using AVM.Core.Entities;
using AVM.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AVM.Business
{
    public class ShiftManager
    {
        private UnitOfWork _uow;

        public ShiftManager()
        {
            _uow = new UnitOfWork();
        }

        public List<Shift> GetShiftsByEmployee(int employeeId)
        {
            return _uow.Shifts.GetAll()
                       .Where(s => s.EmployeeId == employeeId && s.StartTime >= DateTime.Today)
                       .OrderBy(s => s.StartTime)
                       .ToList();
        }
    }
}
