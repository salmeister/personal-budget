using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Income
{
    public class EditModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public EditModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Income Income { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Income = await _context.Income
                .Include(i => i.FamilyMember)
                .Include(i => i.IncomeSource)
                .Include(i => i.Month)
                .Include(i => i.Year).FirstOrDefaultAsync(m => m.IncomePk == id);

            if (Income == null)
            {
                return NotFound();
            }
           ViewData["FamilyMemberId"] = new SelectList(_context.FamilyMembers, "FamilyMemberPk", "FirstName");
           ViewData["IncomeSourceId"] = new SelectList(_context.IncomeSources, "IncomeSourcePk", "IncomeSourceAcro");
           ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
           ViewData["YearId"] = new SelectList(_context.Years, "YearPk", "YearPk");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Income).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(Income.IncomePk))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Month = Income.MonthId, Year = Income.YearId });
        }

        private bool IncomeExists(int id)
        {
            return _context.Income.Any(e => e.IncomePk == id);
        }
    }
}
