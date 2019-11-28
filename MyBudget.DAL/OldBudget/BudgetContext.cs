using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyBudget.DAL.OldBudget.Entities;

namespace MyBudget.DAL.OldBudget
{
    public partial class BudgetContext : DbContext
    {
        public BudgetContext()
        {
        }

        public BudgetContext(DbContextOptions<OldBudget.BudgetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OldBudget.Entities.Expenses> Expenses { get; set; }
        public virtual DbSet<OldBudget.Entities.FamilyMembers> FamilyMembers { get; set; }
        public virtual DbSet<OldBudget.Entities.Income> Income { get; set; }
        public virtual DbSet<OldBudget.Entities.IncomeSources> IncomeSources { get; set; }
        public virtual DbSet<OldBudget.Entities.Institutions> Institutions { get; set; }
        public virtual DbSet<OldBudget.Entities.InsurPayments> InsurPayments { get; set; }
        public virtual DbSet<OldBudget.Entities.Insurance> Insurance { get; set; }
        public virtual DbSet<OldBudget.Entities.InsuranceTypes> InsuranceTypes { get; set; }
        public virtual DbSet<OldBudget.Entities.JoinInsurFamilyMember> JoinInsurFamilyMember { get; set; }
        public virtual DbSet<OldBudget.Entities.JoinLoanFamilyMember> JoinLoanFamilyMember { get; set; }
        public virtual DbSet<OldBudget.Entities.JoinTagTagTypes> JoinTagTagTypes { get; set; }
        public virtual DbSet<OldBudget.Entities.JoinVehicleExpenseTag> JoinVehicleExpenseTag { get; set; }
        public virtual DbSet<OldBudget.Entities.Loan> Loan { get; set; }
        public virtual DbSet<OldBudget.Entities.LoanPayments> LoanPayments { get; set; }
        public virtual DbSet<OldBudget.Entities.LoanTypes> LoanTypes { get; set; }
        public virtual DbSet<OldBudget.Entities.Months> Months { get; set; }
        public virtual DbSet<OldBudget.Entities.Properties> Properties { get; set; }
        public virtual DbSet<OldBudget.Entities.TagTypes> TagTypes { get; set; }
        public virtual DbSet<OldBudget.Entities.Tags> Tags { get; set; }
        public virtual DbSet<OldBudget.Entities.Tuition> Tuition { get; set; }
        public virtual DbSet<OldBudget.Entities.TuitionPayments> TuitionPayments { get; set; }
        public virtual DbSet<OldBudget.Entities.VehicleExpenses> VehicleExpenses { get; set; }
        public virtual DbSet<OldBudget.Entities.Vehicles> Vehicles { get; set; }
        public virtual DbSet<OldBudget.Entities.Years> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Budget");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OldBudget.Entities.Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpensePk)
                    .HasName("PK__expenses__404B333BDA21E6E5");

                entity.ToTable("expenses");

                entity.Property(e => e.ExpensePk).HasColumnName("expense_pk");

                entity.Property(e => e.AceHardwareAmount)
                    .HasColumnName("ace_hardware_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CableAmount)
                    .HasColumnName("cable_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CableDueDate)
                    .HasColumnName("cable_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.CellPhoneAmount)
                    .HasColumnName("cell_phone_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CellPhoneDueDate)
                    .HasColumnName("cell_phone_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.CostcoAmount)
                    .HasColumnName("costco_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DaycareAmount)
                    .HasColumnName("daycare_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ElectricAmount)
                    .HasColumnName("electric_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ElectricDueDate)
                    .HasColumnName("electric_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.FleetFarmAmount)
                    .HasColumnName("fleet_farm_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GarbageAmount)
                    .HasColumnName("garbage_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GarbageDueDate)
                    .HasColumnName("garbage_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.GasAmount)
                    .HasColumnName("gas_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GasDueDate)
                    .HasColumnName("gas_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.GasolineAmount)
                    .HasColumnName("gasoline_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GroceriesAmount)
                    .HasColumnName("groceries_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GymAmount)
                    .HasColumnName("gym_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.GymDueDate)
                    .HasColumnName("gym_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.HealthcareAmount)
                    .HasColumnName("healthcare_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.HealthcareDueDate)
                    .HasColumnName("healthcare_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.HomeDepotAmount)
                    .HasColumnName("home_depot_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.HomeImprovementsAmount)
                    .HasColumnName("home_improvements_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.HouseholdGoodsAmount)
                    .HasColumnName("household_goods_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InternetAmount)
                    .HasColumnName("internet_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.InternetDueDate)
                    .HasColumnName("internet_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.MenardsAmount)
                    .HasColumnName("menards_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.PhoneAmount)
                    .HasColumnName("phone_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PhoneDueDate)
                    .HasColumnName("phone_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.SamsClubAmount)
                    .HasColumnName("sams_club_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.TargetAmount)
                    .HasColumnName("target_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.WalmartAmount)
                    .HasColumnName("walmart_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.WaterAmount)
                    .HasColumnName("water_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.WaterDueDate)
                    .HasColumnName("water_dueDate")
                    .HasColumnType("date");

                entity.Property(e => e.YearId).HasColumnName("year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.FamilyMembers>(entity =>
            {
                entity.HasKey(e => e.FamilyMemberPk)
                    .HasName("PK__family_m__E420B88DD4297E72");

                entity.ToTable("family_members");

                entity.Property(e => e.FamilyMemberPk).HasColumnName("family_member_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middle_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.Income>(entity =>
            {
                entity.HasKey(e => e.IncomePk)
                    .HasName("PK__income__8DC68FBB06D21152");

                entity.ToTable("income");

                entity.Property(e => e.IncomePk).HasColumnName("income_pk");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.IncomeAmount)
                    .HasColumnName("income_amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IncomeRecdate)
                    .HasColumnName("income_recdate")
                    .HasColumnType("date");

                entity.Property(e => e.IncomeSourceId).HasColumnName("income_source_id");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.IncomeSources>(entity =>
            {
                entity.HasKey(e => e.IncomeSourcePk)
                    .HasName("PK__income_s__729DA0FBF8F9517B");

                entity.ToTable("income_sources");

                entity.Property(e => e.IncomeSourcePk).HasColumnName("income_source_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.IncomeSourceAcro)
                    .HasColumnName("income_source_acro")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.IncomeSourceName)
                    .HasColumnName("income_source_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.Institutions>(entity =>
            {
                entity.HasKey(e => e.InstitutionPk)
                    .HasName("PK__institut__E4E9E3BEA20F3ADF");

                entity.ToTable("institutions");

                entity.Property(e => e.InstitutionPk).HasColumnName("institution_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.InstitutionAddress1)
                    .HasColumnName("institution_address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionAddress2)
                    .HasColumnName("institution_address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionCity)
                    .HasColumnName("institution_city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionName)
                    .HasColumnName("institution_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionState)
                    .HasColumnName("institution_state")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.InstitutionZip)
                    .HasColumnName("institution_zip")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.InsurPayments>(entity =>
            {
                entity.HasKey(e => e.InsurPaymentPk)
                    .HasName("PK__insur_pa__3E149F07D18084A2");

                entity.ToTable("insur_payments");

                entity.Property(e => e.InsurPaymentPk).HasColumnName("insur_payment_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("date");

                entity.Property(e => e.InsurId).HasColumnName("insur_id");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.Insurance>(entity =>
            {
                entity.HasKey(e => e.InsurPk)
                    .HasName("PK__insuranc__AAF0F94C4B61CED8");

                entity.ToTable("insurance");

                entity.Property(e => e.InsurPk).HasColumnName("insur_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.InsurAlias)
                    .IsRequired()
                    .HasColumnName("insur_alias")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsurTypeId).HasColumnName("insur_type_id");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<OldBudget.Entities.InsuranceTypes>(entity =>
            {
                entity.HasKey(e => e.InsurTypePk)
                    .HasName("PK__insuranc__441C9F03A788F867");

                entity.ToTable("insurance_types");

                entity.Property(e => e.InsurTypePk).HasColumnName("insur_type_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.InsurTypeName)
                    .HasColumnName("insur_type_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.JoinInsurFamilyMember>(entity =>
            {
                entity.HasKey(e => e.JoinPk)
                    .HasName("PK__join_ins__D6F6A71ED9897FB7");

                entity.ToTable("join_insur_family_member");

                entity.Property(e => e.JoinPk).HasColumnName("join_pk");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.InsurId).HasColumnName("insur_id");
            });

            modelBuilder.Entity<OldBudget.Entities.JoinLoanFamilyMember>(entity =>
            {
                entity.HasKey(e => e.JoinPk)
                    .HasName("PK__join_loa__D6F6A71E51341DB7");

                entity.ToTable("join_loan_family_member");

                entity.Property(e => e.JoinPk).HasColumnName("join_pk");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");
            });

            modelBuilder.Entity<OldBudget.Entities.JoinTagTagTypes>(entity =>
            {
                entity.HasKey(e => e.JoinPk)
                    .HasName("PK__join_tag__D6F6A71EEE26814E");

                entity.ToTable("join_tag_tag_types");

                entity.Property(e => e.JoinPk).HasColumnName("join_pk");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.TagTypeId).HasColumnName("tag_type_id");
            });

            modelBuilder.Entity<OldBudget.Entities.JoinVehicleExpenseTag>(entity =>
            {
                entity.HasKey(e => e.JoinPk)
                    .HasName("PK__join_veh__D6F6A71E7D44FBE7");

                entity.ToTable("join_vehicle_expense_tag");

                entity.Property(e => e.JoinPk).HasColumnName("join_pk");

                entity.Property(e => e.TagId).HasColumnName("tag_id");

                entity.Property(e => e.VehicleExpenseId).HasColumnName("vehicle_expense_id");
            });

            modelBuilder.Entity<OldBudget.Entities.Loan>(entity =>
            {
                entity.HasKey(e => e.LoanPk)
                    .HasName("PK__loan__A1F8CE6ACA56D654");

                entity.ToTable("loan");

                entity.Property(e => e.LoanPk).HasColumnName("loan_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.LoanAlias)
                    .IsRequired()
                    .HasColumnName("loan_alias")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoanTypeId).HasColumnName("loan_type_id");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            });

            modelBuilder.Entity<OldBudget.Entities.LoanPayments>(entity =>
            {
                entity.HasKey(e => e.LoanPaymentPk)
                    .HasName("PK__loan_pay__DEF6898CBBF73FBD");

                entity.ToTable("loan_payments");

                entity.Property(e => e.LoanPaymentPk).HasColumnName("loan_payment_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("date");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.LoanTypes>(entity =>
            {
                entity.HasKey(e => e.LoanTypePk)
                    .HasName("PK__loan_typ__9B1BDEC16FA5DC9D");

                entity.ToTable("loan_types");

                entity.Property(e => e.LoanTypePk).HasColumnName("loan_type_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.LoanTypeName)
                    .HasColumnName("loan_type_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.Months>(entity =>
            {
                entity.HasKey(e => e.MonthPk)
                    .HasName("PK__months__05AFD89721274210");

                entity.ToTable("months");

                entity.Property(e => e.MonthPk)
                    .HasColumnName("month_pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.MonthAbbr)
                    .HasColumnName("month_abbr")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MonthName)
                    .HasColumnName("month_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.Properties>(entity =>
            {
                entity.HasKey(e => e.PropertyPk)
                    .HasName("PK__properti__735BEC8AD77879DA");

                entity.ToTable("properties");

                entity.Property(e => e.PropertyPk).HasColumnName("property_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.PropertyAddress1)
                    .HasColumnName("property_address1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyAddress2)
                    .HasColumnName("property_address2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyCity)
                    .HasColumnName("property_city")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyName)
                    .HasColumnName("property_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyState)
                    .HasColumnName("property_state")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyZip)
                    .HasColumnName("property_zip")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.TagTypes>(entity =>
            {
                entity.HasKey(e => e.TagTypePk)
                    .HasName("PK__tag_type__4D78D40EE8A9E2FE");

                entity.ToTable("tag_types");

                entity.Property(e => e.TagTypePk).HasColumnName("tag_type_pk");

                entity.Property(e => e.TagTypeName)
                    .IsRequired()
                    .HasColumnName("tag_type_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.Tags>(entity =>
            {
                entity.HasKey(e => e.TagPk)
                    .HasName("PK__tags__42969A57C2820567");

                entity.ToTable("tags");

                entity.Property(e => e.TagPk).HasColumnName("tag_pk");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasColumnName("tag_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.Tuition>(entity =>
            {
                entity.HasKey(e => e.TuitionPk)
                    .HasName("PK__tuition__7B81E5179533C85E");

                entity.ToTable("tuition");

                entity.Property(e => e.TuitionPk).HasColumnName("tuition_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.InstitutionId).HasColumnName("institution_id");

                entity.Property(e => e.TuitionAlias)
                    .HasColumnName("tuition_alias")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OldBudget.Entities.TuitionPayments>(entity =>
            {
                entity.HasKey(e => e.TuitionPaymentPk)
                    .HasName("PK__tuition___507E9F1EBBD5BC30");

                entity.ToTable("tuition_payments");

                entity.Property(e => e.TuitionPaymentPk).HasColumnName("tuition_payment_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("date");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.TuitionId).HasColumnName("tuition_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.VehicleExpenses>(entity =>
            {
                entity.HasKey(e => e.VehicleExpensePk)
                    .HasName("PK__vehicle___9F1FF73FF11457D0");

                entity.ToTable("vehicle_expenses");

                entity.Property(e => e.VehicleExpensePk).HasColumnName("vehicle_expense_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Duedate)
                    .HasColumnName("duedate")
                    .HasColumnType("date");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehiclePk)
                    .HasName("PK__vehicles__F294B2F3BD78D1B6");

                entity.ToTable("vehicles");

                entity.Property(e => e.VehiclePk).HasColumnName("vehicle_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.VehicleMake)
                    .HasColumnName("vehicle_make")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleModel)
                    .HasColumnName("vehicle_model")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleName)
                    .HasColumnName("vehicle_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleYearId).HasColumnName("vehicle_year_id");
            });

            modelBuilder.Entity<OldBudget.Entities.Years>(entity =>
            {
                entity.HasKey(e => e.YearPk)
                    .HasName("PK__years__B2A0224E7F83B1CF");

                entity.ToTable("years");

                entity.Property(e => e.YearPk)
                    .HasColumnName("year_pk")
                    .ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
