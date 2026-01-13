using AVM.Core.Entities;
using AVM.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System;

namespace AVM.Business
{
    public class LeaveRequestManager
    {
        private UnitOfWork _uow;

        public LeaveRequestManager()
        {
            _uow = new UnitOfWork();
        }

        public List<LeaveRequest> GetRequestsByEmployee(int employeeId)
        {
            return _uow.LeaveRequests.GetAll()
                       .Where(r => r.EmployeeId == employeeId)
                       .OrderByDescending(r => r.CreatedAt)
                       .ToList();
        }
        
        public List<LeaveRequest> GetRequestsByStore(int storeId)
        {
            return _uow.LeaveRequests.GetAll()
                       .Include(r => r.Employee)
                       .Where(r => r.Employee.StoreId == storeId)
                       .OrderByDescending(r => r.CreatedAt)
                       .ToList();
        }

        public List<LeaveRequest> GetAVMPersonnelRequests()
        {
            // AVM Personnel -> StoreId is NULL
            return _uow.LeaveRequests.GetAll()
                       .Include(r => r.Employee)
                       .Where(r => r.Employee.StoreId == null)
                       .OrderByDescending(r => r.CreatedAt)
                       .ToList();
        }

        public void AddRequest(LeaveRequest request)
        {
            if (request.StartDate > request.EndDate)
                throw new Exception("Bitiş tarihi başlangıçtan önce olamaz.");
            
            _uow.LeaveRequests.Add(request);
            _uow.Save();
        }

        public void UpdateStatus(int leaveId, string status, string rejectionReason = null)
        {
            var req = _uow.LeaveRequests.Get(leaveId);
            if(req != null)
            {
                req.Status = status;
                if(!string.IsNullOrEmpty(rejectionReason))
                {
                    req.RejectionReason = rejectionReason;
                }
                _uow.LeaveRequests.Update(req);
                _uow.Save();
            }
        }
    }
}
