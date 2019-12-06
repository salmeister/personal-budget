using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public DAL.Expenses Expenses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Expenses, Object>>[] { x => x.ExpenseType };
            Expenses = (await _repoWrapper.Expenses.Get(m => m.ExpensePk == id, includes)).FirstOrDefault();

            if (Expenses == null)
            {
                return NotFound();
            }
            ViewData["ExpenseTypeId"] = new SelectList(await _repoWrapper.ExpenseTypes.GetAll(), "ExpenseTypePk", "ExpenseType");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoWrapper.Expenses.Update(Expenses);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await ExpensesExists(Expenses.ExpensePk)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Month = Expenses.MonthId, Year = Expenses.YearId });
        }

        private async Task<bool> ExpensesExists(int id)
        {
            return !(await _repoWrapper.Payments.Find(id) == null);
        }
    }
}
