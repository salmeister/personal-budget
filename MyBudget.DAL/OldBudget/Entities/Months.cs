using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Months
    {
        public int MonthPk { get; set; }
        public string MonthAbbr { get; set; }
        public string MonthName { get; set; }
    }
}
