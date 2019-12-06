using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Insurance
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IList<DAL.Insurance> Insurance { get;set; }

        public async Task OnGetAsync()
        {
            var includes = new Expression<Func<DAL.Insurance, Object>>[] { x => x.FamilyMember, x => x.InsuranceType, x => x.Property, x => x.Vehicle };
            Insurance = await _repoWrapper.Insurance.GetAll(includes);
        }
    }
}
