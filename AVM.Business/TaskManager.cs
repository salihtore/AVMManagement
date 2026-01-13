using AVM.Core.Entities;
using AVM.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AVM.Business
{
    public class TaskManager
    {
        private UnitOfWork _uow;

        public TaskManager()
        {
            _uow = new UnitOfWork();
        }

        public List<EmployeeTask> GetTasksByEmployee(int employeeId)
        {
            return _uow.Tasks.GetAll()
                       .Where(t => t.EmployeeId == employeeId)
                       .OrderBy(t => t.IsCompleted)
                       .ThenByDescending(t => t.AssignedAt)
                       .ToList();
        }

        public void CompleteTask(int taskId)
        {
            var task = _uow.Tasks.Get(taskId);
            if(task != null)
            {
                task.IsCompleted = true;
                task.CompletedAt = DateTime.Now;
                _uow.Tasks.Update(task);
                _uow.Save();
            }
        }
    }
}
