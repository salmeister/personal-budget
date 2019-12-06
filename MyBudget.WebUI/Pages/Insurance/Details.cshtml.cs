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
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DetailsModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public DAL.Insurance Insurance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var includes = new Expression<Func<DAL.Insurance, Object>>[] { x => x.FamilyMember, x => x.InsuranceType, x => x.Property, x => x.Vehicle };
            Insurance = (await _repoWrapper.Insurance.Get(m => m.InsurancePk == id, includes)).FirstOrDefault();

            if (Insurance == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
