using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI
{
    public class IndexModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        public IList<ImportDescriptions> ImportDescriptions { get;set; }

        public async Task OnGetAsync()
        {
            ImportDescriptions = await _context.ImportDescriptions
                .Include(i => i.ExpenseType)
                .Include(i => i.Insurance)
                .Include(i => i.Loan)
                .Include(i => i.Tuition)
                .Include(i => i.IncomeSource).OrderBy(i => i.Description).ToListAsync();
        }
    }
}
