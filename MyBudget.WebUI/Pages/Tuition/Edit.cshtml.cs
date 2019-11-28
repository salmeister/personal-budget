using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Tuition
{
    public class EditModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public EditModel(MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Tuition Tuition { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tuition = await _context.Tuition
                .Include(t => t.FamilyMember)
                .Include(t => t.Institution).FirstOrDefaultAsync(m => m.TuitionPk == id);

            if (Tuition == null)
            {
                return NotFound();
            }
           ViewData["FamilyMemberId"] = new SelectList(_context.FamilyMembers, "FamilyMemberPk", "FirstName");
           ViewData["InstitutionId"] = new SelectList(_context.Institutions, "InstitutionPk", "InstitutionName");
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

            _context.Attach(Tuition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TuitionExists(Tuition.TuitionPk))
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

        private bool TuitionExists(int id)
        {
            return _context.Tuition.Any(e => e.TuitionPk == id);
        }
    }
}
