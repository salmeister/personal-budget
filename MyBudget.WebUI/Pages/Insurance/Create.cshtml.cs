using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Insurance
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
            ViewData["InsuranceTypeId"] = new SelectList(await _repoWrapper.InsuranceTypes.Get(s => s.Active), "InsurTypePk", "InsurTypeName");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            return Page();
        }

        [BindProperty]
        public DAL.Insurance Insurance { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repoWrapper.Insurance.Add(Insurance);
            await _repoWrapper.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
