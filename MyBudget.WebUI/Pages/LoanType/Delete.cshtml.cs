using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.LoanType
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public LoanTypes LoanTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoanTypes = (await _repoWrapper.LoanTypes.Get(m => m.LoanTypePk == id)).FirstOrDefault();

            if (LoanTypes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LoanTypes = await _repoWrapper.LoanTypes.Find(id.Value);

            if (LoanTypes != null)
            {
                _repoWrapper.LoanTypes.Delete(LoanTypes);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
