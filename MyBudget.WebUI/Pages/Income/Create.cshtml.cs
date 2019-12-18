using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Income
{
    public class CreateModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public CreateModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int Month, int Year)
        {
            Income = new DAL.Income() { MonthId = Month, YearId = Year };
            ViewData["FamilyMemberId"] = new SelectList(_context.FamilyMembers, "FamilyMemberPk", "FirstName");
            ViewData["IncomeSourceId"] = new SelectList(_context.IncomeSources, "IncomeSourcePk", "IncomeSourceAcro");
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");
            return Page();
        }

        [BindProperty]
        public DAL.Income Income { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Income.Add(Income);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
