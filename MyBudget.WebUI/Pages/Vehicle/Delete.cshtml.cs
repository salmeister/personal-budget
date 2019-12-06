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
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public Vehicles Vehicles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Vehicles, Object>>[] { x => x.VehicleYear };
            Vehicles = (await _repoWrapper.Vehicles.Get(m => m.VehiclePk == id, includes)).FirstOrDefault();

            if (Vehicles == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vehicles = await _repoWrapper.Vehicles.Find(id.Value);

            if (Vehicles != null)
            {
                _repoWrapper.Vehicles.Delete(Vehicles);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
