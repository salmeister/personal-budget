using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Vehicles
    {
        public int VehiclePk { get; set; }
        public string VehicleName { get; set; }
        public string VehicleModel { get; set; }
        public string VehicleMake { get; set; }
        public int? VehicleYearId { get; set; }
        public bool Active { get; set; }
    }
}
