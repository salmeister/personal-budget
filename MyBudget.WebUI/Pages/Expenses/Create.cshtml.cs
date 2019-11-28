using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public CreateModel(MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypePk", "ExpenseType");
        ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
        ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");
            return Page();
        }

        [BindProperty]
        public DAL.Expenses Expenses { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Expenses.Add(Expenses);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
