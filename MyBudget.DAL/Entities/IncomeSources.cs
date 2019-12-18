using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class IncomeSources
    {
        public IncomeSources()
        {
            ImportDescriptions = new HashSet<ImportDescriptions>();
            Income = new HashSet<Income>();
        }

        public int IncomeSourcePk { get; set; }
        [DisplayName("Acro")]
        public string IncomeSourceAcro { get; set; }
        [DisplayName("Name")]
        public string IncomeSourceName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<ImportDescriptions> ImportDescriptions { get; set; }
        public virtual ICollection<Income> Income { get; set; }
    }
}
