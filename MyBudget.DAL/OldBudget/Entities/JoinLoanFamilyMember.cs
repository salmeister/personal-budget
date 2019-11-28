using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class JoinLoanFamilyMember
    {
        public int JoinPk { get; set; }
        public int LoanId { get; set; }
        public int FamilyMemberId { get; set; }
    }
}
