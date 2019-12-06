using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Tuition
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public DAL.Tuition Tuition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Tuition, Object>>[] { x => x.FamilyMember, x => x.Institution };
            Tuition = (await _repoWrapper.Tuition.Get(m => m.TuitionPk == id, includes)).FirstOrDefault();

            if (Tuition == null)
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

            Tuition = await _repoWrapper.Tuition.Find(id.Value);

            if (Tuition != null)
            {
                _repoWrapper.Tuition.Delete(Tuition);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
