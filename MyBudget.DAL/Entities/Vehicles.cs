using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MyBudget.DAL
{
    public partial class Vehicles
    {
        public Vehicles()
        {
            Insurance = new HashSet<Insurance>();
            Loans = new HashSet<Loans>();
            Payments = new HashSet<Payments>();
        }

        public int VehiclePk { get; set; }
        [DisplayName("Name")]
        public string VehicleName { get; set; }
        [DisplayName("Model")]
        public string VehicleModel { get; set; }
        [DisplayName("Make")]
        public string VehicleMake { get; set; }
        public int? VehicleYearId { get; set; }
        public bool Active { get; set; }

        [DisplayName("Year")]
        public virtual Years VehicleYear { get; set; }
        public virtual ICollection<Insurance> Insurance { get; set; }
        public virtual ICollection<Loans> Loans { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
    }
}
