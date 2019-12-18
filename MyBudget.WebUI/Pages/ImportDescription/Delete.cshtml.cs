using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI
{
    public class DeleteModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DeleteModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ImportDescriptions ImportDescriptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ImportDescriptions = await _context.ImportDescriptions
                .Include(i => i.ExpenseType)
                .Include(i => i.Insurance)
                .Include(i => i.Loan)
                .Include(i => i.Tuition)
                .Include(i => i.IncomeSource).FirstOrDefaultAsync(m => m.ImportDescriptionPk == id);

            if (ImportDescriptions == null)
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

            ImportDescriptions = await _context.ImportDescriptions.FindAsync(id);

            if (ImportDescriptions != null)
            {
                _context.ImportDescriptions.Remove(ImportDescriptions);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
