using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Loan
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DetailsModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public Loans Loans { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Loans, Object>>[] { x => x.FamilyMember, x => x.LoanType, x => x.Property, x => x.Vehicle };
            Loans = (await _repoWrapper.Loans.Get(m => m.LoanPk == id, includes)).FirstOrDefault();

            if (Loans == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
