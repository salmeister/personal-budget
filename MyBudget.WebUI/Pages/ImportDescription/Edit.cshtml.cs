using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI
{
    public class EditModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public EditModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ImportDescriptions ImportDescriptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ImportDescriptions = await _context.ImportDescriptions
                .Include(i => i.ExpenseType)
                .Include(i => i.Insurance)
                .Include(i => i.Loan)
                .Include(i => i.Tuition)
                .Include(i => i.IncomeSource).FirstOrDefaultAsync(m => m.ImportDescriptionPk == id);

            if (ImportDescriptions == null)
            {
                return NotFound();
            }
           ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypePk", "ExpenseType");
           ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsurancePk", "InsuranceAlias");
           ViewData["LoanId"] = new SelectList(_context.Loans, "LoanPk", "LoanAlias");
           ViewData["TuitionId"] = new SelectList(_context.Tuition, "TuitionPk", "TuitionAlias");
            ViewData["IncomeSourceId"] = new SelectList(_context.IncomeSources, "IncomeSourcePk", "IncomeSourceAcro");
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

            _context.Attach(ImportDescriptions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImportDescriptionsExists(ImportDescriptions.ImportDescriptionPk))
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

        private bool ImportDescriptionsExists(int id)
        {
            return _context.ImportDescriptions.Any(e => e.ImportDescriptionPk == id);
        }
    }
}
