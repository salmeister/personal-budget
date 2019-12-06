using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Loan
{
    public class CreateModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CreateModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<IActionResult> OnGet()
        {

            ViewData["FamilyMemberId"] = new SelectList(await _repoWrapper.FamilyMembers.Get(s => s.Active), "FamilyMemberPk", "FirstName");
            ViewData["LoanTypeId"] = new SelectList(await _repoWrapper.LoanTypes.Get(s => s.Active), "LoanTypePk", "LoanTypeName");
            ViewData["PropertyId"] = new SelectList(await _repoWrapper.Properties.Get(s => s.Active), "PropertyPk", "PropertyName");
            ViewData["VehicleId"] = new SelectList(await _repoWrapper.Vehicles.Get(s => s.Active), "VehiclePk", "VehicleName");

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

            await _repoWrapper.Loans.Add(Loans);
            await _repoWrapper.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
