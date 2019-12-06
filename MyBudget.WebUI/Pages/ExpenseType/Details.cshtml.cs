using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.ExpenseType
{
    public class DetailsModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DetailsModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public ExpenseTypes ExpenseTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ExpenseTypes = (await _repoWrapper.ExpenseTypes.Get(m => m.ExpenseTypePk == id)).FirstOrDefault();

            if (ExpenseTypes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
