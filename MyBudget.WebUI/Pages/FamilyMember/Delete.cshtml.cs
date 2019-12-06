using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.FamilyMember
{
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public FamilyMembers FamilyMembers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FamilyMembers = (await _repoWrapper.FamilyMembers.Get(m => m.FamilyMemberPk == id)).FirstOrDefault();

            if (FamilyMembers == null)
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

            FamilyMembers = await _repoWrapper.FamilyMembers.Find(id.Value);

            if (FamilyMembers != null)
            {
                _repoWrapper.FamilyMembers.Delete(FamilyMembers);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
