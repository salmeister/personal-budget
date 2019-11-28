using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Income
    {
        public int IncomePk { get; set; }
        public int IncomeSourceId { get; set; }
        public int FamilyMemberId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal IncomeAmount { get; set; }
        public DateTime? IncomeRecdate { get; set; }
    }
}
