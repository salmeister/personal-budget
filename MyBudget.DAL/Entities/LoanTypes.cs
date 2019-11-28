using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class LoanTypes
    {
        public LoanTypes()
        {
            Loans = new HashSet<Loans>();
        }

        public int LoanTypePk { get; set; }
        [DisplayName("Type")]
        public string LoanTypeName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Loans> Loans { get; set; }
    }
}
