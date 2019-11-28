using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Properties
    {
        public Properties()
        {
            Insurance = new HashSet<Insurance>();
            Loans = new HashSet<Loans>();
        }

        public int PropertyPk { get; set; }
        [DisplayName("Name")]
        public string PropertyName { get; set; }
        [DisplayName("Address 1")]
        public string PropertyAddress1 { get; set; }
        [DisplayName("Address 2")]
        public string PropertyAddress2 { get; set; }
        [DisplayName("City")]
        public string PropertyCity { get; set; }
        [DisplayName("State")]
        public string PropertyState { get; set; }
        [DisplayName("Zip")]
        public string PropertyZip { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Insurance> Insurance { get; set; }
        public virtual ICollection<Loans> Loans { get; set; }
    }
}
