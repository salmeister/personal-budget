using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Loan
{
    public class EditModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public EditModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["FamilyMemberId"] = new SelectList(_context.FamilyMembers, "FamilyMemberPk", "FirstName");
           ViewData["LoanTypeId"] = new SelectList(_context.LoanTypes, "LoanTypePk", "LoanTypeName");
           ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyPk", "PropertyName");
           ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclePk", "VehicleName");
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

            _context.Attach(Loans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoansExists(Loans.LoanPk))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LoansExists(int id)
        {
            return _context.Loans.Any(e => e.LoanPk == id);
        }
    }
}
