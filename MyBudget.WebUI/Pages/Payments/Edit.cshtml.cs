using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Payments
{
    public class EditModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public EditModel(MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Payments Payments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payments = await _context.Payments
                .Include(p => p.Insurance)
                .Include(p => p.Loan)
                .Include(p => p.Month)
                .Include(p => p.Tuition)
                .Include(p => p.Vehicle)
                .Include(p => p.Year).FirstOrDefaultAsync(m => m.PaymentPk == id);

            if (Payments == null)
            {
                return NotFound();
            }
           ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsurancePk", "InsuranceAlias");
           ViewData["LoanId"] = new SelectList(_context.Loans, "LoanPk", "LoanAlias");
           ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
           ViewData["TuitionId"] = new SelectList(_context.Tuition, "TuitionPk", "TuitionAlias");
           ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclePk", "VehicleName");
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

            _context.Attach(Payments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentsExists(Payments.PaymentPk))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Month = Payments.MonthId, Year = Payments.YearId });
        }

        private bool PaymentsExists(int id)
        {
            return _context.Payments.Any(e => e.PaymentPk == id);
        }
    }
}
