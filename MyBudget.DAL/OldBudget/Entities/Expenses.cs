using System;
using System.Collections.Generic;

namespace MyBudget.DAL.OldBudget.Entities
{
    public partial class Expenses
    {
        public int ExpensePk { get; set; }
        public int MonthId { get; set; }
        public int YearId { get; set; }
        public decimal? GasAmount { get; set; }
        public DateTime? GasDueDate { get; set; }
        public decimal? ElectricAmount { get; set; }
        public DateTime? ElectricDueDate { get; set; }
        public decimal? WaterAmount { get; set; }
        public DateTime? WaterDueDate { get; set; }
        public decimal? GarbageAmount { get; set; }
        public DateTime? GarbageDueDate { get; set; }
        public decimal? GymAmount { get; set; }
        public DateTime? GymDueDate { get; set; }
        public decimal? HealthcareAmount { get; set; }
        public DateTime? HealthcareDueDate { get; set; }
        public decimal? HouseholdGoodsAmount { get; set; }
        public decimal? GroceriesAmount { get; set; }
        public decimal? TargetAmount { get; set; }
        public decimal? WalmartAmount { get; set; }
        public decimal? SamsClubAmount { get; set; }
        public decimal? CostcoAmount { get; set; }
        public decimal? HomeImprovementsAmount { get; set; }
        public decimal? MenardsAmount { get; set; }
        public decimal? HomeDepotAmount { get; set; }
        public decimal? AceHardwareAmount { get; set; }
        public decimal? FleetFarmAmount { get; set; }
        public decimal? DaycareAmount { get; set; }
        public decimal? GasolineAmount { get; set; }
        public decimal? CellPhoneAmount { get; set; }
        public DateTime? CellPhoneDueDate { get; set; }
        public decimal? PhoneAmount { get; set; }
        public DateTime? PhoneDueDate { get; set; }
        public decimal? CableAmount { get; set; }
        public DateTime? CableDueDate { get; set; }
        public decimal? InternetAmount { get; set; }
        public DateTime? InternetDueDate { get; set; }
    }
}
