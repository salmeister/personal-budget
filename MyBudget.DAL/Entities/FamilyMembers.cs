using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class FamilyMembers
    {
        public FamilyMembers()
        {
            Income = new HashSet<Income>();
            Insurance = new HashSet<Insurance>();
            Loans = new HashSet<Loans>();
            Tuition = new HashSet<Tuition>();
        }

        public int FamilyMemberPk { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Income> Income { get; set; }
        public virtual ICollection<Insurance> Insurance { get; set; }
        public virtual ICollection<Loans> Loans { get; set; }
        public virtual ICollection<Tuition> Tuition { get; set; }
    }
}
