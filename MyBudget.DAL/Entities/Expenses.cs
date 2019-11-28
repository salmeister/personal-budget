using System;
using System.Collections.Generic;

namespace MyBudget.DAL
{
    public partial class Expenses
    {
        public int ExpensePk { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public int ExpenseTypeId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? DueDate { get; set; }

        public virtual ExpenseTypes ExpenseType { get; set; }
        public virtual Months Month { get; set; }
        public virtual Years Year { get; set; }
    }
}
