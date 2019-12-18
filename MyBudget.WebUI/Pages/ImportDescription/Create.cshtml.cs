using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI
{
    public class CreateModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public CreateModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ExpenseTypeId"] = new SelectList(_context.ExpenseTypes, "ExpenseTypePk", "ExpenseType");
        ViewData["InsuranceId"] = new SelectList(_context.Insurance, "InsurancePk", "InsuranceAlias");
        ViewData["LoanId"] = new SelectList(_context.Loans, "LoanPk", "LoanAlias");
        ViewData["TuitionId"] = new SelectList(_context.Tuition, "TuitionPk", "TuitionAlias");
        ViewData["IncomeSourceId"] = new SelectList(_context.IncomeSources, "IncomeSourcePk", "IncomeSourceAcro");
            return Page();
        }

        [BindProperty]
        public ImportDescriptions ImportDescriptions { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ImportDescriptions.Add(ImportDescriptions);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
