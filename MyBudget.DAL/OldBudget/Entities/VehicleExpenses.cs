using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class VehicleExpenses
    {
        public int VehicleExpensePk { get; set; }
        public int VehicleId { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal Amount { get; set; }
        public DateTime? Duedate { get; set; }
    }
}
