using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Payments
{
    public class CreateModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public CreateModel(MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int Month, int Year)
        {
            Payments = new DAL.Payments() { MonthId = Month, YearId = Year };
            ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsurancePk", "InsuranceAlias");
            ViewData["LoanId"] = new SelectList(_context.Loans, "LoanPk", "LoanAlias");
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
            ViewData["TuitionId"] = new SelectList(_context.Tuition, "TuitionPk", "TuitionAlias");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclePk", "VehicleName");
            ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");
            return Page();
        }

        [BindProperty]
        public DAL.Payments Payments { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Payments.Add(Payments);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { Month = Payments.MonthId, Year = Payments.YearId });
        }
    }
}
