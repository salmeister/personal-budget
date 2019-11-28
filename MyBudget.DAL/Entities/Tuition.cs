using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Tuition
    {
        public Tuition()
        {
            Payments = new HashSet<Payments>();
        }

        public int TuitionPk { get; set; }
        [DisplayName("Alias")]
        public string TuitionAlias { get; set; }
        public int FamilyMemberId { get; set; }
        public int InstitutionId { get; set; }
        public bool Active { get; set; }

        [DisplayName("Family Member")]
        public virtual FamilyMembers FamilyMember { get; set; }
        public virtual Institutions Institution { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
