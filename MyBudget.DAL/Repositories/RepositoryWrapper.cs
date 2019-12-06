using MyBudget.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBudget.DAL.Repositories
{
    public interface IRepositoryWrapper
    {
        IExpensesRepository Expenses { get; }
        IExpenseTypesRepository ExpenseTypes { get; }
        IFamilyMembersRepository FamilyMembers { get; }
        IIncomeRepository Income { get; }
        IIncomeSourcesRepository IncomeSources { get; }
        IInstitutionsRepository Institutions { get; }
        IInsuranceRepository Insurance { get; }
        IInsuranceTypesRepository InsuranceTypes { get; }
        ILoansRepository Loans { get; }
        ILoanTypesRepository LoanTypes { get; }
        IMonthsRepository Months { get; }
        IPaymentsRepository Payments { get; }
        IPropertiesRepository Properties { get; }
        ITuitionRepository Tuition { get; }
        IVehiclesRepository Vehicles { get; }
        IYearsRepository Years { get; }
        Task SaveChanges();
    }

    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MyBudgetContext _context;
        private IExpensesRepository _expenses;
        private IExpenseTypesRepository _expenseTypes;
        private IFamilyMembersRepository _familyMembers;
        private IIncomeRepository _income;
        private IIncomeSourcesRepository _incomeSources;
        private IInstitutionsRepository _institutions;
        private IInsuranceRepository _insurance;
        private IInsuranceTypesRepository _insuranceTypes;
        private ILoansRepository _loans;
        private ILoanTypesRepository _loanTypes;
        private IMonthsRepository _months;
        private IPaymentsRepository _payments;
        private IPropertiesRepository _properties;
        private ITuitionRepository _tuition;
        private IVehiclesRepository _vehicles;
        private IYearsRepository _years;

        public RepositoryWrapper(MyBudgetContext context)
        {
            _context = context;
        }

        public IExpensesRepository Expenses
        {
            get
            {
                if (_expenses == null)
                {
                    _expenses = new ExpensesRepository(_context);
                }

                return _expenses;
            }
        }

        public IExpenseTypesRepository ExpenseTypes
        {
            get
            {
                if (_expenseTypes == null)
                {
                    _expenseTypes = new ExpenseTypesRepository(_context);
                }

                return _expenseTypes;
            }
        }

        public IFamilyMembersRepository FamilyMembers
        {
            get
            {
                if (_familyMembers == null)
                {
                    _familyMembers = new FamilyMembersRepository(_context);
                }

                return _familyMembers;
            }
        }

        public IIncomeRepository Income
        {
            get
            {
                if (_income == null)
                {
                    _income = new IncomeRepository(_context);
                }

                return _income;
            }
        }

        public IIncomeSourcesRepository IncomeSources
        {
            get
            {
                if (_incomeSources == null)
                {
                    _incomeSources = new IncomeSourcesRepository(_context);
                }

                return _incomeSources;
            }
        }

        public IInstitutionsRepository Institutions
        {
            get
            {
                if (_institutions == null)
                {
                    _institutions = new InstitutionsRepository(_context);
                }

                return _institutions;
            }
        }

        public IInsuranceRepository Insurance
        {
            get
            {
                if (_insurance == null)
                {
                    _insurance = new InsuranceRepository(_context);
                }

                return _insurance;
            }
        }

        public IInsuranceTypesRepository InsuranceTypes
        {
            get
            {
                if (_insuranceTypes == null)
                {
                    _insuranceTypes = new InsuranceTypesRepository(_context);
                }

                return _insuranceTypes;
            }
        }

        public ILoansRepository Loans
        {
            get
            {
                if (_loans == null)
                {
                    _loans = new LoansRepository(_context);
                }

                return _loans;
            }
        }

        public ILoanTypesRepository LoanTypes
        {
            get
            {
                if (_loanTypes == null)
                {
                    _loanTypes = new LoanTypesRepository(_context);
                }

                return _loanTypes;
            }
        }

        public IMonthsRepository Months
        {
            get
            {
                if (_months == null)
                {
                    _months = new MonthsRepository(_context);
                }

                return _months;
            }
        }

        public IPaymentsRepository Payments
        {
            get
            {
                if (_payments == null)
                {
                    _payments = new PaymentsRepository(_context);
                }

                return _payments;
            }
        }

        public IPropertiesRepository Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new PropertiesRepository(_context);
                }

                return _properties;
            }
        }

        public ITuitionRepository Tuition
        {
            get
            {
                if (_tuition == null)
                {
                    _tuition = new TuitionRepository(_context);
                }

                return _tuition;
            }
        }

        public IVehiclesRepository Vehicles
        {
            get
            {
                if (_vehicles == null)
                {
                    _vehicles = new VehiclesRepository(_context);
                }

                return _vehicles;
            }
        }

        public IYearsRepository Years
        {
            get
            {
                if (_years == null)
                {
                    _years = new YearsRepository(_context);
                }

                return _years;
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
