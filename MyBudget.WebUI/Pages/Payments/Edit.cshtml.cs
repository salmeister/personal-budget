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
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public DAL.Payments Payments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Payments, Object>>[] { x => x.Loan, x => x.Insurance, x => x.Tuition, x => x.Vehicle };
            Payments = (await _repoWrapper.Payments.Get(m => m.PaymentPk == id, includes)).FirstOrDefault();

            if (Payments == null)
            {
                return NotFound();
            }
            ViewData["InsuranceId"] = new SelectList(await _repoWrapper.Insurance.GetAll(), "InsurancePk", "InsuranceAlias");
            ViewData["LoanId"] = new SelectList(await _repoWrapper.Loans.GetAll(), "LoanPk", "LoanAlias");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["TuitionId"] = new SelectList(await _repoWrapper.Tuition.GetAll(), "TuitionPk", "TuitionAlias");
            ViewData["VehicleId"] = new SelectList(await _repoWrapper.Vehicles.GetAll(), "VehiclePk", "VehiclePk");
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

            _repoWrapper.Payments.Update(Payments);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await PaymentsExists(Payments.PaymentPk)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Month = Payments.MonthId, Year = Payments.YearId });
        }

        private async Task<bool> PaymentsExists(int id)
        {
            return !(await _repoWrapper.Payments.Find(id) == null);
        }
    }
}
