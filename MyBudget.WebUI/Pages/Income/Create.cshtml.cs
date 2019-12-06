using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Income
{
    public class CreateModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CreateModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<IActionResult> OnGet(int Month, int Year)
        {
            Income = new DAL.Income() { MonthId = Month, YearId = Year };
            ViewData["FamilyMemberId"] = new SelectList(await _repoWrapper.FamilyMembers.Get(s => s.Active), "FamilyMemberPk", "FirstName");
            ViewData["IncomeSourceId"] = new SelectList(await _repoWrapper.IncomeSources.Get(s => s.Active), "IncomeSourcePk", "IncomeSourceAcro");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            
            return Page();
        }

        [BindProperty]
        public DAL.Income Income { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repoWrapper.Income.Add(Income);
            await _repoWrapper.SaveChanges();

            return RedirectToPage("./Index", new { Month = Income.MonthId, Year = Income.YearId });
        }
    }
}
