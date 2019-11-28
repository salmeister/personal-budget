using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Loan
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
        ViewData["FamilyMemberId"] = new SelectList(_context.FamilyMembers, "FamilyMemberPk", "FirstName");
        ViewData["LoanTypeId"] = new SelectList(_context.LoanTypes, "LoanTypePk", "LoanTypeName");
        ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyPk", "PropertyName");
        ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclePk", "VehicleName");
            return Page();
        }

        [BindProperty]
        public Loans Loans { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Loans.Add(Loans);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
