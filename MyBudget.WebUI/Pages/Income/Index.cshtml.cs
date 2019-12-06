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
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        //Model
        public IList<DAL.Income> Income { get;set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public async Task OnGetAsync(int? Month, int? Year)
        {
            if (Month is null)
            {
                DateTime today = DateTime.Now;
                Month = today.Month;
                Year = today.Year;
            }
            this.Month = Month.Value;
            this.Year = Year.Value;

            var includes = new Expression<Func<DAL.Income, Object>>[] { x => x.FamilyMember, x => x.IncomeSource };
            Income = await _repoWrapper.Income.Get(m => m.MonthId == Month && m.YearId == Year, includes);

            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
        }

        public async Task<IActionResult> OnPostAsync(int Month, int Year)
        {
            this.Year = Year;
            this.Month = Month;

            var includes = new Expression<Func<DAL.Income, Object>>[] { x => x.FamilyMember, x => x.IncomeSource };
            Income = await _repoWrapper.Income.Get(m => m.MonthId == Month && m.YearId == Year, includes);

            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            return Page();
        }
    }
}
