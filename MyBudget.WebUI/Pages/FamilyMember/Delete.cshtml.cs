using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.FamilyMember
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DeleteModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FamilyMembers FamilyMembers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FamilyMembers = await _context.FamilyMembers.FirstOrDefaultAsync(m => m.FamilyMemberPk == id);

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

            FamilyMembers = await _context.FamilyMembers.FindAsync(id);

            if (FamilyMembers != null)
            {
                _context.FamilyMembers.Remove(FamilyMembers);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
