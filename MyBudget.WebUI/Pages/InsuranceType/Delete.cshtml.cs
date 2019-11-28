using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.InsuranceType
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DeleteModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InsuranceTypes InsuranceTypes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            InsuranceTypes = await _context.InsuranceTypes.FirstOrDefaultAsync(m => m.InsurTypePk == id);

            if (InsuranceTypes == null)
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

            InsuranceTypes = await _context.InsuranceTypes.FindAsync(id);

            if (InsuranceTypes != null)
            {
                _context.InsuranceTypes.Remove(InsuranceTypes);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
