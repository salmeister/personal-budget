using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.ExpenseType
{
    public class CreateModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public CreateModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ExpenseTypes ExpenseTypes { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ExpenseTypes.Add(ExpenseTypes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
