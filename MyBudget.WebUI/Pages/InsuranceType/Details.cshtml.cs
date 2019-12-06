using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.InsuranceType
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DetailsModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public InsuranceTypes InsuranceTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InsuranceTypes = (await _repoWrapper.InsuranceTypes.Get(m => m.InsurTypePk == id)).FirstOrDefault();

            if (InsuranceTypes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
