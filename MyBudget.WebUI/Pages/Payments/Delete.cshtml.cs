using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Payments
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DeleteModel(MyBudget.DAL.MyBudgetContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Payments = await _context.Payments.FindAsync(id);

            if (Payments != null)
            {
                _context.Payments.Remove(Payments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
