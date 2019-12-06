using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Payments
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
            Payments = new DAL.Payments() { MonthId = Month, YearId = Year };
            ViewData["InsuranceId"] = new SelectList(await _repoWrapper.Insurance.Get(s => s.Active), "InsurancePk", "InsuranceAlias");
            ViewData["LoanId"] = new SelectList(await _repoWrapper.Loans.Get(s => s.Active), "LoanPk", "LoanAlias");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["TuitionId"] = new SelectList(await _repoWrapper.Tuition.Get(s => s.Active), "TuitionPk", "TuitionAlias");
            ViewData["VehicleId"] = new SelectList(await _repoWrapper.Vehicles.Get(s => s.Active), "VehiclePk", "VehiclePk");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            return Page();
        }

        [BindProperty]
        public DAL.Payments Payments { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repoWrapper.Payments.Add(Payments);
            await _repoWrapper.SaveChanges();

            return RedirectToPage("./Index", new { Month = Payments.MonthId, Year = Payments.YearId  });
        }
    }
}
