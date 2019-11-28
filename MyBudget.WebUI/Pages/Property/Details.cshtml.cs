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
    public class DetailsModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DetailsModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

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
    }
}
