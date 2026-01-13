using AVM.Core.Entities;
using AVM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM.Business
{
    public class PersonnelManager
    {
        private UnitOfWork _uow;

        public PersonnelManager()
        {
            _uow = new UnitOfWork();
        }

        // ============================
        // ADMIN OPERATIONS
        // ============================

        public List<Employee> GetAllEmployees()
        {
            return _uow.Employees.GetAll().ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _uow.Employees.Get(id);
        }

        public void AddEmployee(string fullName, string position, decimal salary, string phone, string status, DateTime startDate)
        {
            var emp = new Employee
            {
                FullName = fullName,
                Position = position,
                Salary = salary,
                Phone = phone,
                Status = status,
                StartDate = startDate,
                ShiftStart = "09:00",
                ShiftEnd = "18:00",
                WorkedDays = 0,
                // Defaulting StoreId and UserId to null initially
                StoreId = null,
                UserId = null
            };
            _uow.Employees.Add(emp);
            _uow.Save();
        }

        public void DeleteEmployee(int id)
        {
            _uow.Employees.Delete(id);
            _uow.Save();
        }

        public void UpdateEmployee(int id, string fullName, string position, decimal salary, int? storeId, string shiftStart, string shiftEnd)
        {
            var emp = _uow.Employees.Get(id);
            if (emp != null)
            {
                emp.FullName = fullName;
                emp.Position = position;
                emp.Salary = salary;
                emp.StoreId = storeId;
                emp.ShiftStart = shiftStart;
                emp.ShiftEnd = shiftEnd;
                _uow.Employees.Update(emp);
                _uow.Save();
            }
        }

        // ============================
        // PERSONNEL OPERATIONS
        // ============================

        public Employee GetEmployeeByUserId(int userId)
        {
            // Since Repository might not have custom queries, we get all and filter (inefficient but works for small scale)
            // Or use Find(predicate) if Repository supports it. Assuming standard generic repo:
            var all = _uow.Employees.GetAll();
            return all.FirstOrDefault(e => e.UserId == userId);
        }

        public void LinkUserToEmployee(int employeeId, int userId)
        {
             var emp = _uow.Employees.Get(employeeId);
             if(emp != null)
             {
                 emp.UserId = userId;
                 _uow.Employees.Update(emp);
                 _uow.Save();
             }
        }

    }
}
