using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Loans
    {
        public Loans()
        {
            Payments = new HashSet<Payments>();
        }

        public int LoanPk { get; set; }
        [DisplayName("Loan Alias")]
        public string LoanAlias { get; set; }
        public int LoanTypeId { get; set; }
        public int? FamilyMemberId { get; set; }
        public int? PropertyId { get; set; }
        public int? VehicleId { get; set; }
        public bool Active { get; set; }

        [DisplayName("Family Member")]
        public virtual FamilyMembers FamilyMember { get; set; }
        [DisplayName("Loan Type")]
        public virtual LoanTypes LoanType { get; set; }
        public virtual Properties Property { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
