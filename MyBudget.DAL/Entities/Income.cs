using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Income
    {
        public int IncomePk { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public int FamilyMemberId { get; set; }
        public int IncomeSourceId { get; set; }
        public decimal? Amount { get; set; }
        [DisplayName("Received")]
        public DateTime? ReceivedDate { get; set; }

        [DisplayName("Family Member")]
        public virtual FamilyMembers FamilyMember { get; set; }
        [DisplayName("Income Source")]
        public virtual IncomeSources IncomeSource { get; set; }
        public virtual Months Month { get; set; }
        public virtual Years Year { get; set; }
    }
}
