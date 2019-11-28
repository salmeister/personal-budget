using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Institutions
    {
        public int InstitutionPk { get; set; }
        public string InstitutionName { get; set; }
        public string InstitutionAddress1 { get; set; }
        public string InstitutionAddress2 { get; set; }
        public string InstitutionCity { get; set; }
        public string InstitutionState { get; set; }
        public string InstitutionZip { get; set; }
        public bool Active { get; set; }
    }
}
