using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expenses = await _repoWrapper.Expenses.Find(id.Value);

            if (Expenses != null)
            {
                _repoWrapper.Expenses.Delete(Expenses);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index", new { Month = Expenses.MonthId, Year = Expenses.YearId });
        }
    }
}
