using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Loan
{
    public class IndexModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IList<Loans> Loans { get;set; }

        public async Task OnGetAsync()
        {
            Loans = await _context.Loans
                .Include(l => l.FamilyMember)
                .Include(l => l.LoanType)
                .Include(l => l.Property)
                .Include(l => l.Vehicle).ToListAsync();
        }
    }
}
