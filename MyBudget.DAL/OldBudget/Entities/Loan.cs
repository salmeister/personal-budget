using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Loan
    {
        public int LoanPk { get; set; }
        public int LoanTypeId { get; set; }
        public string LoanAlias { get; set; }
        public int? PropertyId { get; set; }
        public int? VehicleId { get; set; }
        public bool? Active { get; set; }
    }
}
