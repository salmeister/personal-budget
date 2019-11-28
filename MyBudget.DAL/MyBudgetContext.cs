using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBudget.DAL
{
    public partial class MyBudgetContext : DbContext
    {
        public MyBudgetContext()
        {
        }

        public MyBudgetContext(DbContextOptions<MyBudgetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExpenseTypes> ExpenseTypes { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<FamilyMembers> FamilyMembers { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<IncomeSources> IncomeSources { get; set; }
        public virtual DbSet<Institutions> Institutions { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<InsuranceTypes> InsuranceTypes { get; set; }
        public virtual DbSet<LoanTypes> LoanTypes { get; set; }
        public virtual DbSet<Loans> Loans { get; set; }
        public virtual DbSet<Months> Months { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Properties> Properties { get; set; }
        public virtual DbSet<Tuition> Tuition { get; set; }
        public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Years> Years { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExpenseTypes>(entity =>
            {
                entity.HasKey(e => e.ExpenseTypePk);

                entity.ToTable("expense_types");

                entity.Property(e => e.ExpenseTypePk).HasColumnName("expense_type_pk");

                entity.Property(e => e.ExpenseType)
                    .IsRequired()
                    .HasColumnName("expense_type")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ExpenseTypeAbbr)
                    .HasColumnName("expense_type_abbr")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expenses>(entity =>
            {
                entity.HasKey(e => e.ExpensePk);

                entity.ToTable("expenses");

                entity.Property(e => e.ExpensePk).HasColumnName("expense_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.ExpenseTypeId).HasColumnName("expense_type_id");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");

                entity.HasOne(d => d.ExpenseType)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.ExpenseTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_expenses_expense_types");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_expenses_months");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_expenses_years");
            });

            modelBuilder.Entity<FamilyMembers>(entity =>
            {
                entity.HasKey(e => e.FamilyMemberPk)
                    .HasName("PK__family_m__E420B88DE7886AB8");

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

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasKey(e => e.IncomePk);

                entity.ToTable("income");

                entity.Property(e => e.IncomePk).HasColumnName("income_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.IncomeSourceId).HasColumnName("income_source_id");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnName("received_date")
                    .HasColumnType("date");

                entity.Property(e => e.YearId).HasColumnName("year_id");

                entity.HasOne(d => d.FamilyMember)
                    .WithMany(p => p.Income)
                    .HasForeignKey(d => d.FamilyMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_income_family_members");

                entity.HasOne(d => d.IncomeSource)
                    .WithMany(p => p.Income)
                    .HasForeignKey(d => d.IncomeSourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_income_income_sources");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.Income)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_income_months");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Income)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_income_years");
            });

            modelBuilder.Entity<IncomeSources>(entity =>
            {
                entity.HasKey(e => e.IncomeSourcePk)
                    .HasName("PK__income_s__729DA0FB2E8050AD");

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

            modelBuilder.Entity<Institutions>(entity =>
            {
                entity.HasKey(e => e.InstitutionPk)
                    .HasName("PK__institut__E4E9E3BE9AA1928A");

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

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.HasKey(e => e.InsurancePk);

                entity.ToTable("insurance");

                entity.Property(e => e.InsurancePk).HasColumnName("insurance_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.InsuranceAlias)
                    .IsRequired()
                    .HasColumnName("insurance_alias")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceTypeId).HasColumnName("insurance_type_id");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.FamilyMember)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.FamilyMemberId)
                    .HasConstraintName("FK_insurance_family_members");

                entity.HasOne(d => d.InsuranceType)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.InsuranceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_insurance_insurance_types");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK_insurance_properties");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_insurance_vehicles");
            });

            modelBuilder.Entity<InsuranceTypes>(entity =>
            {
                entity.HasKey(e => e.InsurTypePk)
                    .HasName("PK__insuranc__441C9F03D792A0AD");

                entity.ToTable("insurance_types");

                entity.Property(e => e.InsurTypePk).HasColumnName("insur_type_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.InsurTypeName)
                    .HasColumnName("insur_type_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoanTypes>(entity =>
            {
                entity.HasKey(e => e.LoanTypePk)
                    .HasName("PK__loan_typ__9B1BDEC196626295");

                entity.ToTable("loan_types");

                entity.Property(e => e.LoanTypePk).HasColumnName("loan_type_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.LoanTypeName)
                    .HasColumnName("loan_type_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Loans>(entity =>
            {
                entity.HasKey(e => e.LoanPk);

                entity.ToTable("loans");

                entity.Property(e => e.LoanPk).HasColumnName("loan_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.LoanAlias)
                    .IsRequired()
                    .HasColumnName("loan_alias")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LoanTypeId).HasColumnName("loan_type_id");

                entity.Property(e => e.PropertyId).HasColumnName("property_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.HasOne(d => d.FamilyMember)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.FamilyMemberId)
                    .HasConstraintName("FK_loans_family_members");

                entity.HasOne(d => d.LoanType)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LoanTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loans_loan_types");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.PropertyId)
                    .HasConstraintName("FK_loans_properties");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_loans_vehicles");
            });

            modelBuilder.Entity<Months>(entity =>
            {
                entity.HasKey(e => e.MonthPk);

                entity.ToTable("months");

                entity.Property(e => e.MonthPk)
                    .HasColumnName("month_pk")
                    .ValueGeneratedNever();

                entity.Property(e => e.MonthAbbr)
                    .IsRequired()
                    .HasColumnName("month_abbr")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.MonthName)
                    .IsRequired()
                    .HasColumnName("month_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentPk);

                entity.ToTable("payments");

                entity.Property(e => e.PaymentPk).HasColumnName("payment_pk");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DueDate)
                    .HasColumnName("due_date")
                    .HasColumnType("date");

                entity.Property(e => e.InsuranceId).HasColumnName("insurance_id");

                entity.Property(e => e.LoanId).HasColumnName("loan_id");

                entity.Property(e => e.MonthId).HasColumnName("month_id");

                entity.Property(e => e.TuitionId).HasColumnName("tuition_id");

                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                entity.Property(e => e.YearId).HasColumnName("year_id");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("FK_payments_insurance");

                entity.HasOne(d => d.Loan)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.LoanId)
                    .HasConstraintName("FK_payments_loans");

                entity.HasOne(d => d.Month)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.MonthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payments_months");

                entity.HasOne(d => d.Tuition)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.TuitionId)
                    .HasConstraintName("FK_payments_tuition");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.VehicleId)
                    .HasConstraintName("FK_payments_vehicles");

                entity.HasOne(d => d.Year)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.YearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_payments_years");
            });

            modelBuilder.Entity<Properties>(entity =>
            {
                entity.HasKey(e => e.PropertyPk)
                    .HasName("PK__properti__735BEC8A27C52347");

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

            modelBuilder.Entity<Tuition>(entity =>
            {
                entity.HasKey(e => e.TuitionPk);

                entity.ToTable("tuition");

                entity.Property(e => e.TuitionPk).HasColumnName("tuition_pk");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FamilyMemberId).HasColumnName("family_member_id");

                entity.Property(e => e.InstitutionId).HasColumnName("institution_id");

                entity.Property(e => e.TuitionAlias)
                    .IsRequired()
                    .HasColumnName("tuition_alias")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FamilyMember)
                    .WithMany(p => p.Tuition)
                    .HasForeignKey(d => d.FamilyMemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tuition_family_members");

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.Tuition)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tuition_institutions");
            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.HasKey(e => e.VehiclePk);

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

                entity.HasOne(d => d.VehicleYear)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleYearId)
                    .HasConstraintName("FK_vehicles_years");
            });

            modelBuilder.Entity<Years>(entity =>
            {
                entity.HasKey(e => e.YearPk);

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
