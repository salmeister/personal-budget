using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;

namespace MyBudget.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly MyBudget.DAL.MyBudgetContext _context;

        public IndexModel(ILogger<IndexModel> logger, MyBudget.DAL.MyBudgetContext context)
        {
            _logger = logger;

            _context = context;
        }

        public void OnGet()
        {

        }


    }
}
