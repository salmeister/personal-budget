using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Tuition
{
    public class DetailsModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public DetailsModel(MyBudgetContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
