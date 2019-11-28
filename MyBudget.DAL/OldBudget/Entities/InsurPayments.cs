using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class InsurPayments
    {
        public int InsurPaymentPk { get; set; }
        public int InsurId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Duedate { get; set; }
    }
}
