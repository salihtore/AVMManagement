using AVM.Core.Entities;
using AVM.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AVM.Business
{
    public class EmployeeManager
    {
        private UnitOfWork _uow;

        public EmployeeManager()
        {
            _uow = new UnitOfWork();
        }

        public List<Employee> GetEmployeesByStore(int storeId)
        {
            return _uow.Employees.GetAll()
                       .Where(e => e.StoreId == storeId)
                       .OrderBy(e => e.FullName)
                       .ToList();
        }

        public void AddEmployee(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.FullName))
                throw new Exception("Ad Soyad zorunludur.");

            employee.Status = "Active";
            _uow.Employees.Add(employee);
            _uow.Save();
        }

        public void RemoveEmployee(int id)
        {
            var emp = _uow.Employees.Get(id);
            if(emp != null)
            {
                emp.Status = "Inactive"; // Soft delete
                _uow.Employees.Update(emp);
                _uow.Save();
            }
        }
    }
}
