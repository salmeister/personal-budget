using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyBudget.WebUI.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IList<DAL.Payments> Payments { get;set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public async Task OnGetAsync(int? Month, int? Year)
        {
            await GetPaymentData(Month, Year);
        }

        public async Task<IActionResult> OnPostAsync(int Month, int Year)
        {
            await GetPaymentData(Month, Year);
            return Page();
        }

        private async Task GetPaymentData(int? Month, int? Year)
        {
            if (Month is null)
            {
                DateTime today = DateTime.Now;
                Month = today.Month;
                Year = today.Year;
            }
            this.Year = Year.Value;
            this.Month = Month.Value;

            Payments = await _context.Payments
                .Include(p => p.Insurance)
                .Include(p => p.Loan)
                .Include(p => p.Month)
                .Include(p => p.Tuition)
                .Include(p => p.Vehicle)
                .Include(p => p.Year).Where(p => p.MonthId == Month && p.YearId == Year).ToListAsync();

            ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");
        }
    }
}
