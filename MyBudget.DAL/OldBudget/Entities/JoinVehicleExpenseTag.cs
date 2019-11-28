using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class JoinVehicleExpenseTag
    {
        public int JoinPk { get; set; }
        public int VehicleExpenseId { get; set; }
        public int TagId { get; set; }
    }
}
