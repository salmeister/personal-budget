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
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IList<Loans> Loans { get;set; }

        public async Task OnGetAsync()
        {
            var includes = new Expression<Func<DAL.Loans, Object>>[] { x => x.FamilyMember, x => x.LoanType, x => x.Property, x => x.Vehicle };
            Loans = await _repoWrapper.Loans.GetAll();
        }
    }
}
