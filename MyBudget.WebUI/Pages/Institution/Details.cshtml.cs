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
    public class DetailsModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DetailsModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

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
    }
}
