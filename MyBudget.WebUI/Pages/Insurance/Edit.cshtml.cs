using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Insurance
{
    public class EditModel : PageModel
    {
        private readonly MyBudget.DAL.MyBudgetContext _context;

        public EditModel(MyBudget.DAL.MyBudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DAL.Insurance Insurance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Insurance = await _context.Insurance
                .Include(i => i.FamilyMember)
                .Include(i => i.InsuranceType)
                .Include(i => i.Property)
                .Include(i => i.Vehicle).FirstOrDefaultAsync(m => m.InsurancePk == id);

            if (Insurance == null)
            {
                return NotFound();
            }
           ViewData["FamilyMemberId"] = new SelectList(_context.FamilyMembers, "FamilyMemberPk", "FirstName");
           ViewData["InsuranceTypeId"] = new SelectList(_context.InsuranceTypes, "InsurTypePk", "InsurTypeName");
           ViewData["PropertyId"] = new SelectList(_context.Properties, "PropertyPk", "PropertyName");
           ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehiclePk", "VehicleName");
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

            _context.Attach(Insurance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(Insurance.InsurancePk))
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

        private bool InsuranceExists(int id)
        {
            return _context.Insurance.Any(e => e.InsurancePk == id);
        }
    }
}
