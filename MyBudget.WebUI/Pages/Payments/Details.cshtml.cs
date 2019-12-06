using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Payments
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DetailsModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

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
            return Page();
        }
    }
}
