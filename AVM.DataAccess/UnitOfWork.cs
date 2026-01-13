using System;
using AVM.Core.Entities;
using AVM.DataAccess.Context;
using AVM.DataAccess.Repositories;
using AVM.DataAccess.Interfaces;

namespace AVM.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        private readonly AVMContext _context;
        private bool _disposed = false;

        public UnitOfWork()
        {
            _context = new AVMContext();

            Users = new Repository<User>(_context);
            Roles = new Repository<Role>(_context);
            Tenants = new Repository<Tenant>(_context);
            Stores = new Repository<Store>(_context);
            Contracts = new Repository<Contract>(_context);
            Rents = new Repository<Rent>(_context);
            Payments = new Repository<Payment>(_context);
            Expenses = new Repository<Expense>(_context);
            CommonExpenses = new Repository<CommonExpense>(_context);
            ExpenseCategories = new Repository<ExpenseCategory>(_context);
            Employees = new Repository<Employee>(_context);
            Tickets = new Repository<Ticket>(_context);
            Announcements = new Repository<Announcement>(_context);
            Messages = new Repository<Message>(_context);
            
            Turnovers = new Repository<Turnover>(_context);
            ServiceRequests = new Repository<ServiceRequest>(_context);
            StoreEmployees = new Repository<StoreEmployee>(_context);
            Shifts = new Repository<Shift>(_context);
            Tasks = new Repository<EmployeeTask>(_context);
            LeaveRequests = new Repository<LeaveRequest>(_context);
        }

        public IRepository<User> Users { get; }
        public IRepository<Role> Roles { get; }
        public IRepository<Tenant> Tenants { get; }
        public IRepository<Store> Stores { get; }
        public IRepository<Contract> Contracts { get; }
        public IRepository<Rent> Rents { get; }
        public IRepository<Payment> Payments { get; }
        public IRepository<Expense> Expenses { get; }
        public IRepository<CommonExpense> CommonExpenses { get; }
        public IRepository<ExpenseCategory> ExpenseCategories { get; }
        public IRepository<Employee> Employees { get; }
        public IRepository<Ticket> Tickets { get; }
        public IRepository<Announcement> Announcements { get; }
        public IRepository<Message> Messages { get; }

        public IRepository<Turnover> Turnovers { get; }
        public IRepository<ServiceRequest> ServiceRequests { get; }
        public IRepository<StoreEmployee> StoreEmployees { get; }
        public IRepository<Shift> Shifts { get; }
        public IRepository<EmployeeTask> Tasks { get; }
        public IRepository<LeaveRequest> LeaveRequests { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
