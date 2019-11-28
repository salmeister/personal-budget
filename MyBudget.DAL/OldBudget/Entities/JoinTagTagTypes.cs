using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class JoinTagTagTypes
    {
        public int JoinPk { get; set; }
        public int TagId { get; set; }
        public int TagTypeId { get; set; }
    }
}
