using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class ImportDescriptions
    {
        public int ImportDescriptionPk { get; set; }
        public string Description { get; set; }
        public int? ExpenseTypeId { get; set; }
        public int? LoanId { get; set; }
        public int? InsuranceId { get; set; }
        public int? TuitionId { get; set; }
        public int? IncomeSourceId { get; set; }

        [DisplayName("Expense Type")]
        public virtual ExpenseTypes ExpenseType { get; set; }
        public virtual IncomeSources IncomeSource { get; set; }
        public virtual Insurance Insurance { get; set; }
        public virtual Loans Loan { get; set; }
        public virtual Tuition Tuition { get; set; }
    }
}
