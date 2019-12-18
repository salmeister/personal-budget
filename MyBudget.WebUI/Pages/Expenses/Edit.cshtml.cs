using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class EditModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public EditModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Expenses Expenses { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expenses = await _context.Expenses
                .Include(e => e.ExpenseType)
                .Include(e => e.Month)
                .Include(e => e.Year).FirstOrDefaultAsync(m => m.ExpensePk == id);

            if (Expenses == null)
            {
                return NotFound();
            }
           ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypePk", "ExpenseType");
           ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
           ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");
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

            _context.Attach(Expenses).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpensesExists(Expenses.ExpensePk))
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

        private bool ExpensesExists(int id)
        {
            return _context.Expenses.Any(e => e.ExpensePk == id);
        }
    }
}
