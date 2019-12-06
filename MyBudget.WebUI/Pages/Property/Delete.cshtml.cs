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
    public class DeleteModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public DeleteModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        [BindProperty]
        public Properties Properties { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Properties = (await _repoWrapper.Properties.Get(m => m.PropertyPk == id)).FirstOrDefault();

            if (Properties == null)
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

            Properties = await _repoWrapper.Properties.Find(id.Value);

            if (Properties != null)
            {
                _repoWrapper.Properties.Delete(Properties);
                await _repoWrapper.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
