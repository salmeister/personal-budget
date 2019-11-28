using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Tuition
    {
        public int TuitionPk { get; set; }
        public string TuitionAlias { get; set; }
        public int InstitutionId { get; set; }
        public int FamilyMemberId { get; set; }
        public bool? Active { get; set; }
    }
}
