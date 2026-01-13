using AVM.Core.Entities;
using AVM.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AVM.Business
{
    public class StoreEmployeeManager
    {
        private UnitOfWork _uow;

        public StoreEmployeeManager()
        {
            _uow = new UnitOfWork();
        }

        public List<StoreEmployee> GetEmployeesByStore(int storeId)
        {
            return _uow.StoreEmployees.GetAll()
                       .Where(e => e.StoreId == storeId && e.IsActive)
                       .ToList();
        }

        public void AddEmployee(StoreEmployee employee)
        {
            if (string.IsNullOrEmpty(employee.FullName))
                throw new Exception("İsim soyisim boş olamaz.");

            _uow.StoreEmployees.Add(employee);
            _uow.Save();
        }

        public void RemoveEmployee(int employeeId)
        {
            var emp = _uow.StoreEmployees.Get(employeeId);
            if(emp != null)
            {
                emp.IsActive = false; // Soft delete
                _uow.StoreEmployees.Update(emp);
                _uow.Save();
            }
        }
    }
}
