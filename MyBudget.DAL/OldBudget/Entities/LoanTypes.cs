using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class LoanTypes
    {
        public int LoanTypePk { get; set; }
        public string LoanTypeName { get; set; }
        public bool Active { get; set; }
    }
}
