using System;
using System.Collections.Generic;

namespace MyBudget.DAL
{
    public partial class ViewExpenseTotals
    {
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public decimal? Expenses { get; set; }
    }
}
