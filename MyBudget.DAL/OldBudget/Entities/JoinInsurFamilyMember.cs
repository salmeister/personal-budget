using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class JoinInsurFamilyMember
    {
        public int JoinPk { get; set; }
        public int InsurId { get; set; }
        public int FamilyMemberId { get; set; }
    }
}
