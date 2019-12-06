using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Insurance
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public DAL.Insurance Insurance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Insurance, Object>>[] { x => x.FamilyMember, x => x.InsuranceType, x => x.Property, x => x.Vehicle };
            Insurance = (await _repoWrapper.Insurance.Get(m => m.InsurancePk == id, includes)).FirstOrDefault();

            if (Insurance == null)
            {
                return NotFound();
            }

            ViewData["FamilyMemberId"] = new SelectList(await _repoWrapper.FamilyMembers.GetAll(), "FamilyMemberPk", "FirstName");
            ViewData["InsuranceTypeId"] = new SelectList(await _repoWrapper.InsuranceTypes.GetAll(), "InsurTypePk", "InsurTypeName");
            ViewData["PropertyId"] = new SelectList(await _repoWrapper.Properties.GetAll(), "PropertyPk", "PropertyName");
            ViewData["VehicleId"] = new SelectList(await _repoWrapper.Vehicles.GetAll(), "VehiclePk", "VehicleName");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
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

            _repoWrapper.Insurance.Update(Insurance);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await InsuranceExists(Insurance.InsurancePk)))
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

        private async Task<bool> InsuranceExists(int id)
        {
            return !(await _repoWrapper.Insurance.Find(id) == null);
        }
    }
}
