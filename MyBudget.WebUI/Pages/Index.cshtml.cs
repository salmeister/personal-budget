using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;

namespace MyBudget.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyBudget.DAL.MyBudgetContext _context;
        private readonly MyBudget.DAL.OldBudget.BudgetContext _oldContext;

        public IndexModel(ILogger<IndexModel> logger, MyBudget.DAL.MyBudgetContext context, MyBudget.DAL.OldBudget.BudgetContext oldContext)
        {
            _logger = logger;

            _context = context;
            _oldContext = oldContext;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {

            var oldExpenses = await _oldContext.Expenses.ToListAsync();

            foreach (var oldExpense in oldExpenses)
            {
                if (!(oldExpense.CableAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.CableAmount,
                            DueDate = oldExpense.CableDueDate,
                            ExpenseTypeId = 13
                        }
                        );
                }
                if (!(oldExpense.CellPhoneAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.CellPhoneAmount,
                            DueDate = oldExpense.CellPhoneDueDate,
                            ExpenseTypeId = 11
                        }
                        );
                }
                if (!(oldExpense.DaycareAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.DaycareAmount,
                            DueDate = null,
                            ExpenseTypeId = 9
                        }
                        );
                }
                if (!(oldExpense.ElectricAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.ElectricAmount,
                            DueDate = oldExpense.ElectricDueDate,
                            ExpenseTypeId = 2
                        }
                        );
                }
                if (!(oldExpense.GarbageAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.GarbageAmount,
                            DueDate = oldExpense.GarbageDueDate,
                            ExpenseTypeId = 4
                        }
                        );
                }
                if (!(oldExpense.GasAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.GasAmount,
                            DueDate = oldExpense.GasDueDate,
                            ExpenseTypeId = 10
                        }
                        );
                }
                if (!(oldExpense.GasolineAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.GasolineAmount,
                            DueDate = null,
                            ExpenseTypeId = 1
                        }
                        );
                }
                if (!(oldExpense.GroceriesAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.GroceriesAmount,
                            DueDate = null,
                            ExpenseTypeId = 15
                        }
                        );
                }
                if (!(oldExpense.GymAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.GymAmount,
                            DueDate = oldExpense.GymDueDate,
                            ExpenseTypeId = 5
                        }
                        );
                }
                if (!(oldExpense.HealthcareAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.HealthcareAmount,
                            DueDate = oldExpense.HealthcareDueDate,
                            ExpenseTypeId = 6
                        }
                        );
                }
                if (!(oldExpense.HomeImprovementsAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.HomeImprovementsAmount,
                            DueDate = null,
                            ExpenseTypeId = 8
                        }
                        );
                }
                if (!(oldExpense.HouseholdGoodsAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.HouseholdGoodsAmount,
                            DueDate = null,
                            ExpenseTypeId = 7
                        }
                        );
                }
                if (!(oldExpense.InternetAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.InternetAmount,
                            DueDate = oldExpense.InternetDueDate,
                            ExpenseTypeId = 14
                        }
                        );
                }
                if (!(oldExpense.PhoneAmount is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.PhoneAmount,
                            DueDate = oldExpense.PhoneDueDate,
                            ExpenseTypeId = 12
                        }
                        );
                }
                if (!(oldExpense.WaterDueDate is null))
                {
                    _context.Expenses.Add(
                        new DAL.Expenses()
                        {
                            MonthId = oldExpense.MonthId,
                            YearId = oldExpense.YearId,
                            Amount = oldExpense.WaterAmount,
                            DueDate = oldExpense.WaterDueDate,
                            ExpenseTypeId = 3
                        }
                        );
                }
            }
            await _context.SaveChangesAsync();

            return Page();
        }
    }
}
