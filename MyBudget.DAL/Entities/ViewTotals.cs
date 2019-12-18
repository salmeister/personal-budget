using System;
using System.Collections.Generic;

namespace MyBudget.DAL
{
    public partial class ViewTotals
    {
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public decimal? Income { get; set; }
        public decimal? Expenses { get; set; }
        public decimal? Payments { get; set; }
    }
}
