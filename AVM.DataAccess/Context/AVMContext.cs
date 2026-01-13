using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVM.Core.Entities;

namespace AVM.DataAccess.Context
{
    public class AVMContext : DbContext
    {
        public AVMContext() : base("AVMDB")
        {
        }


        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .WillCascadeOnDelete(false);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<CommonExpense> CommonExpenses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        // Future Features
        public DbSet<Turnover> Turnovers { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<StoreEmployee> StoreEmployees { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        // Mapping EmployeeTask to 'Tasks' table
        public DbSet<EmployeeTask> Tasks { get; set; } 
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}