using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Loan
{
    public class DetailsModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DetailsModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public Loans Loans { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Loans = await _context.Loans
                .Include(l => l.FamilyMember)
                .Include(l => l.LoanType)
                .Include(l => l.Property)
                .Include(l => l.Vehicle).FirstOrDefaultAsync(m => m.LoanPk == id);

            if (Loans == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
