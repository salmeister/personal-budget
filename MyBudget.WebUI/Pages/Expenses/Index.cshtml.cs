using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IList<DAL.Expenses> Expenses { get;set; }
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

            var includes = new Expression<Func<DAL.Expenses, Object>>[] { x => x.ExpenseType };
            Expenses = (await _repoWrapper.Expenses.Get(e => e.MonthId == Month && e.YearId == Year, includes)).OrderBy(e => e.ExpenseType.ExpenseType).ToList();

            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.Get(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");
        }

        public async Task<IActionResult> OnPostAsync(int Month, int Year)
        {
            this.Year = Year;
            this.Month = Month;

            var includes = new Expression<Func<DAL.Expenses, Object>>[] { x => x.ExpenseType };
            Expenses = (await _repoWrapper.Expenses.Get(e => e.MonthId == Month && e.YearId == Year, includes)).OrderBy(e => e.ExpenseType.ExpenseType).ToList();

            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.Get(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");
            return Page();
        }
    }
}
