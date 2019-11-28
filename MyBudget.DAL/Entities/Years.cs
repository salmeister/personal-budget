using System;
using System.Collections.Generic;

namespace MyBudget.DAL
{
    public partial class Years
    {
        public Years()
        {
            Expenses = new HashSet<Expenses>();
            Income = new HashSet<Income>();
            Payments = new HashSet<Payments>();
            Vehicles = new HashSet<Vehicles>();
        }

        public int YearPk { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }
        public virtual ICollection<Income> Income { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}
