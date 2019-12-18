using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.IncomeSource
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DeleteModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IncomeSources IncomeSources { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IncomeSources = await _context.IncomeSources.FirstOrDefaultAsync(m => m.IncomeSourcePk == id);

            if (IncomeSources == null)
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

            IncomeSources = await _context.IncomeSources.FindAsync(id);

            if (IncomeSources != null)
            {
                _context.IncomeSources.Remove(IncomeSources);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
