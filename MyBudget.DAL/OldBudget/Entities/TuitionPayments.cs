using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class TuitionPayments
    {
        public int TuitionPaymentPk { get; set; }
        public int TuitionId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Duedate { get; set; }
    }
}
