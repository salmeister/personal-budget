using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.DAL
{
    public partial class Expenses
    {
        public int ExpensePk { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public int ExpenseTypeId { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Amount { get; set; }
        [DisplayName("Due Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DueDate { get; set; }

        [DisplayName("Expense Type")]
        public virtual ExpenseTypes ExpenseType { get; set; }
        public virtual Months Month { get; set; }
        public virtual Years Year { get; set; }
    }
}
