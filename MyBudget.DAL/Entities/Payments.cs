using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.DAL
{
    public partial class Payments
    {
        public int PaymentPk { get; set; }
        public int YearId { get; set; }
        public int MonthId { get; set; }
        public int? LoanId { get; set; }
        public int? InsuranceId { get; set; }
        public int? TuitionId { get; set; }
        public int? VehicleId { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Amount { get; set; }
        [DisplayName("Due Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? DueDate { get; set; }

        public virtual Insurance Insurance { get; set; }
        public virtual Loans Loan { get; set; }
        public virtual Months Month { get; set; }
        public virtual Tuition Tuition { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public virtual Years Year { get; set; }
    }
}
