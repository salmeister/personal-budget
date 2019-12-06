using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Vehicle
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
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
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repoWrapper.Vehicles.Update(Vehicles);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await VehiclesExists(Vehicles.VehiclePk)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> VehiclesExists(int id)
        {
            return !(await _repoWrapper.Vehicles.Find(id) == null);
        }
    }
}
