using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Vehicle
{
    public class IndexModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public IndexModel(MyBudgetContext context)
        {
            _context = context;
        }

        public IList<Vehicles> Vehicles { get;set; }

        public async Task OnGetAsync()
        {
            Vehicles = await _context.Vehicles
                .Include(v => v.VehicleYear).ToListAsync();
        }
    }
}
