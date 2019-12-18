using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Property
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public DeleteModel(MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Properties Properties { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Properties = await _context.Properties.FirstOrDefaultAsync(m => m.PropertyPk == id);

            if (Properties == null)
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

            Properties = await _context.Properties.FindAsync(id);

            if (Properties != null)
            {
                _context.Properties.Remove(Properties);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
