using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class ExpenseTypes
    {
        public ExpenseTypes()
        {
            Expenses = new HashSet<Expenses>();
            ImportDescriptions = new HashSet<ImportDescriptions>();
        }

        public int ExpenseTypePk { get; set; }
        [DisplayName("Expense Type")]
        public string ExpenseType { get; set; }
        [DisplayName("Abbreviation")]
        public string ExpenseTypeAbbr { get; set; }

        public virtual ICollection<Expenses> Expenses { get; set; }
        public virtual ICollection<ImportDescriptions> ImportDescriptions { get; set; }
    }
}
