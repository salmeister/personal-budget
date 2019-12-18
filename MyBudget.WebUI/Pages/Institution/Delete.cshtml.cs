using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Institution
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DeleteModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Institutions Institutions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Institutions = await _context.Institutions.FirstOrDefaultAsync(m => m.InstitutionPk == id);

            if (Institutions == null)
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

            Institutions = await _context.Institutions.FindAsync(id);

            if (Institutions != null)
            {
                _context.Institutions.Remove(Institutions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
