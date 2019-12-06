using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Property
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IList<Properties> Properties { get;set; }

        public async Task OnGetAsync()
        {
            Properties = await _repoWrapper.Properties.GetAll();
        }
    }
}
