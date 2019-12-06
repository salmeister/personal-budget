using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Income
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _repoWrapper.Income.Find(id.Value);

            if (Income != null)
            {
                _repoWrapper.Income.Delete(Income);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index", new { Month = Income.MonthId, Year = Income.YearId });
        }
    }
}
