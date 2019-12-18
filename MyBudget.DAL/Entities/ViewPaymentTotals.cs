using System;
using System.Collections.Generic;

namespace MyBudget.DAL
{
    public partial class ViewPaymentTotals
    {
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public decimal? Payments { get; set; }
    }
}
