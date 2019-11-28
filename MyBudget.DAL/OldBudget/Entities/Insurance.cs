using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Insurance
    {
        public int InsurPk { get; set; }
        public int InsurTypeId { get; set; }
        public string InsurAlias { get; set; }
        public int? PropertyId { get; set; }
        public int? VehicleId { get; set; }
        public bool? Active { get; set; }
    }
}
