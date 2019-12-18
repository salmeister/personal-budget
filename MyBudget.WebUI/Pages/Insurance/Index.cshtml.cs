using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Insurance
{
    public class IndexModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IList<DAL.Insurance> Insurance { get;set; }

        public async Task OnGetAsync()
        {
            Insurance = await _context.Insurance
                .Include(i => i.FamilyMember)
                .Include(i => i.InsuranceType)
                .Include(i => i.Property)
                .Include(i => i.Vehicle).ToListAsync();
        }
    }
}
