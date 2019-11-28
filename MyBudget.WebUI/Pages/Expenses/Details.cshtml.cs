using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class DetailsModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public DetailsModel(MyBudgetContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
