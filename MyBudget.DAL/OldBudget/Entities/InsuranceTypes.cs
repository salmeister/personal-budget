using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class InsuranceTypes
    {
        public int InsurTypePk { get; set; }
        public string InsurTypeName { get; set; }
        public bool Active { get; set; }
    }
}
