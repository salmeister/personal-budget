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
    public class IndexModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IList<DAL.Expenses> Expenses { get;set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public async Task OnGetAsync(int? Month, int? Year)
        {
            await GetData(Month, Year);
        }

        public async Task<IActionResult> OnPostAsync(int Month, int Year)
        {
            await GetData(Month, Year);
            return Page();
        }

        public async Task GetData(int? Month, int? Year)
        {
            if (Month is null)
            {
                DateTime today = DateTime.Now;
                Month = today.Month;
                Year = today.Year;
            }
            this.Month = Month.Value;
            this.Year = Year.Value;

            ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");

            Expenses = await _context.Expenses
                .Include(e => e.ExpenseType)
                .Include(e => e.Month)
                .Include(e => e.Year).Where(e => e.MonthId == Month && e.YearId == Year).ToListAsync();
        }
    }
}
