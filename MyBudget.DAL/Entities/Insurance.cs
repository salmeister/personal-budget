using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Insurance
    {
        public Insurance()
        {
            Payments = new HashSet<Payments>();
        }

        public int InsurancePk { get; set; }
        [DisplayName("Alias")]
        public string InsuranceAlias { get; set; }
        public int InsuranceTypeId { get; set; }
        public int? FamilyMemberId { get; set; }
        public int? PropertyId { get; set; }
        public int? VehicleId { get; set; }
        public bool Active { get; set; }

        [DisplayName("Family Member")]
        public virtual FamilyMembers FamilyMember { get; set; }
        [DisplayName("Type")]
        public virtual InsuranceTypes InsuranceType { get; set; }
        public virtual Properties Property { get; set; }
        public virtual Vehicles Vehicle { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
