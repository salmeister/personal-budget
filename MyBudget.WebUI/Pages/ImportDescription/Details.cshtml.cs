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
    public class DetailsModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DetailsModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

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
                .Include(i => i.Tuition).FirstOrDefaultAsync(m => m.ImportDescriptionPk == id);

            if (ImportDescriptions == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
