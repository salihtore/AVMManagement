using System;
using System.Collections.Generic;
using System.Linq;
using AVM.Core.Entities;
using AVM.DataAccess;

namespace AVM.Business
{
    public class ExpenseManager
    {
        private readonly UnitOfWork _uow;

        public ExpenseManager()
        {
            _uow = new UnitOfWork();
        }

        public List<ExpenseCategory> GetCategories()
        {
            return _uow.ExpenseCategories.GetAll().ToList();
        }

        public object GetAllExpensesDetailed()
        {
            var expenses = _uow.Expenses.GetAll().ToList();
            var categories = _uow.ExpenseCategories.GetAll().ToList();

            var query = from e in expenses
                        join c in categories on e.ExpenseCategoryId equals c.ExpenseCategoryId
                        select new
                        {
                            e.ExpenseId,
                            Category = c.CategoryName,
                            Amount = e.Amount,
                            Date = e.ExpenseDate.ToShortDateString(),
                            Description = e.Description,
                            RawDate = e.ExpenseDate
                        };
            
            return query.OrderByDescending(x => x.RawDate).ToList();
        }

        public void AddExpense(int categoryId, decimal amount, DateTime date, string description)
        {
            var expense = new Expense
            {
                ExpenseCategoryId = categoryId,
                Amount = amount,
                ExpenseDate = date,
                Description = description
            };

            _uow.Expenses.Add(expense);
            _uow.Save(); // Persist
        }

        public void DeleteExpense(int expenseId)
        {
            var expense = _uow.Expenses.Get(expenseId);
            if (expense != null)
            {
                _uow.Expenses.Delete(expenseId);
                _uow.Save(); // Persist
            }
        }
    }
}
