using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class InsuranceTypes
    {
        public InsuranceTypes()
        {
            Insurance = new HashSet<Insurance>();
        }

        public int InsurTypePk { get; set; }
        [DisplayName("Name")]
        public string InsurTypeName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Insurance> Insurance { get; set; }
    }
}
