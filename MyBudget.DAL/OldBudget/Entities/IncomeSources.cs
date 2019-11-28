using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class IncomeSources
    {
        public int IncomeSourcePk { get; set; }
        public string IncomeSourceAcro { get; set; }
        public string IncomeSourceName { get; set; }
        public bool Active { get; set; }
    }
}
