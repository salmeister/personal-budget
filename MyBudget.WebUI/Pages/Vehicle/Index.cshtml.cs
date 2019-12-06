using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Vehicle
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IList<Vehicles> Vehicles { get;set; }

        public async Task OnGetAsync()
        {
            var includes = new Expression<Func<DAL.Vehicles, Object>>[] { x => x.VehicleYear };
            Vehicles = await _repoWrapper.Vehicles.GetAll(includes);
        }
    }
}
