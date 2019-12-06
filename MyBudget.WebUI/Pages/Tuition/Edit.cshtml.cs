using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Tuition
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
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
            ViewData["FamilyMemberId"] = new SelectList(await _repoWrapper.FamilyMembers.GetAll(), "FamilyMemberPk", "FirstName");
            ViewData["InstitutionId"] = new SelectList(await _repoWrapper.Institutions.GetAll(), "InstitutionPk", "InstitutionName");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoWrapper.Tuition.Update(Tuition);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await TuitionExists(Tuition.TuitionPk)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> TuitionExists(int id)
        {
            return !(await _repoWrapper.Tuition.Find(id) == null);
        }
    }
}
