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

namespace MyBudget.WebUI.Pages.Payments
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IList<DAL.Payments> Payments { get;set; }
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
            await GetPaymentData(Month.Value, Year.Value);
        }

        public async Task<IActionResult> OnPostAsync(int Month, int Year)
        {
            await GetPaymentData(Month, Year);
            return Page();
        }

        private async Task GetPaymentData(int Month, int Year)
        {
            this.Year = Year;
            this.Month = Month;

            var includes = new Expression<Func<DAL.Payments, Object>>[] { x => x.Loan, x => x.Insurance, x => x.Tuition, x => x.Vehicle };
            Payments = await _repoWrapper.Payments.Get(p => p.MonthId == Month && p.YearId == Year, includes);

            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.Get(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");
        }
    }
}
