using System;
using System.Collections.Generic;

namespace MyBudget.DAL
{
    public partial class Months
    {
        public Months()
        {
            Expenses = new HashSet<Expenses>();
            Income = new HashSet<Income>();
            Payments = new HashSet<Payments>();
        }

        public int MonthPk { get; set; }
        public string MonthAbbr { get; set; }
        public string MonthName { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }
        public virtual ICollection<Income> Income { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
