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

namespace MyBudget.WebUI.Pages.Loan
{
    public class EditModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public EditModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public Loans Loans { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var includes = new Expression<Func<DAL.Loans, Object>>[] { x => x.FamilyMember, x => x.LoanType, x => x.Property, x => x.Vehicle };
            Loans = (await _repoWrapper.Loans.Get(m => m.LoanPk == id, includes)).FirstOrDefault();

            if (Loans == null)
            {
                return NotFound();
            }
            ViewData["FamilyMemberId"] = new SelectList(await _repoWrapper.FamilyMembers.GetAll(), "FamilyMemberPk", "FirstName");
            ViewData["LoanTypeId"] = new SelectList(await _repoWrapper.LoanTypes.GetAll(), "LoanTypePk", "LoanTypeName");
            ViewData["PropertyId"] = new SelectList(await _repoWrapper.Properties.GetAll(), "PropertyPk", "PropertyName");
            ViewData["VehicleId"] = new SelectList(await _repoWrapper.Vehicles.GetAll(), "VehiclePk", "VehicleName");
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

            _repoWrapper.Loans.Update(Loans);

            try
            {
                await _repoWrapper.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await LoansExists(Loans.LoanPk)))
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

        private async Task<bool> LoansExists(int id)
        {
            return !(await _repoWrapper.Loans.Find(id) == null);
        }
    }
}
