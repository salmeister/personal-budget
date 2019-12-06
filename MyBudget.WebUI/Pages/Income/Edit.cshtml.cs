using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Income
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public DAL.Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Income, Object>>[] { x => x.FamilyMember, x => x.IncomeSource };
            Income = (await _repoWrapper.Income.Get(m => m.IncomePk == id, includes)).FirstOrDefault();

            if (Income == null)
            {
                return NotFound();
            }
            ViewData["FamilyMemberId"] = new SelectList(await _repoWrapper.FamilyMembers.GetAll(), "FamilyMemberPk", "FirstName");
            ViewData["IncomeSourceId"] = new SelectList(await _repoWrapper.IncomeSources.GetAll(), "IncomeSourcePk", "IncomeSourceAcro");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
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

            _repoWrapper.Income.Update(Income);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await IncomeExists(Income.IncomePk)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Month = Income.MonthId, Year = Income.YearId });
        }

        private async Task<bool> IncomeExists(int id)
        {
            return !(await _repoWrapper.Income.Find(id) == null);
        }

    }
}
