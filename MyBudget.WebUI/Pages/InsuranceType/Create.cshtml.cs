using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.InsuranceType
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
        public InsuranceTypes InsuranceTypes { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InsuranceTypes.Add(InsuranceTypes);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
