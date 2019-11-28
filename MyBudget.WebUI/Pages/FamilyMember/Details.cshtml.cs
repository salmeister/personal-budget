using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.FamilyMember
{
    public class DetailsModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public DetailsModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public FamilyMembers FamilyMembers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FamilyMembers = await _context.FamilyMembers.FirstOrDefaultAsync(m => m.FamilyMemberPk == id);

            if (FamilyMembers == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
