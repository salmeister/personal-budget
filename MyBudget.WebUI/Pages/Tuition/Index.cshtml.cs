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
    public class IndexModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IList<DAL.Tuition> Tuition { get;set; }

        public async Task OnGetAsync()
        {
            Tuition = await _context.Tuition
                .Include(t => t.FamilyMember)
                .Include(t => t.Institution).ToListAsync();
        }
    }
}
