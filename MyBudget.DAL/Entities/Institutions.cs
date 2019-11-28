using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Institutions
    {
        public Institutions()
        {
            Tuition = new HashSet<Tuition>();
        }

        public int InstitutionPk { get; set; }
        [DisplayName("Name")]
        public string InstitutionName { get; set; }
        [DisplayName("Address 1")]
        public string InstitutionAddress1 { get; set; }
        [DisplayName("Address 2")]
        public string InstitutionAddress2 { get; set; }
        [DisplayName("City")]
        public string InstitutionCity { get; set; }
        [DisplayName("State")]
        public string InstitutionState { get; set; }
        [DisplayName("Zip")]
        public string InstitutionZip { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Tuition> Tuition { get; set; }
    }
}
