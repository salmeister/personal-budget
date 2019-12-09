﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL.Repositories;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public CreateModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public async Task<IActionResult> OnGet(int Month, int Year)
        {
            Expenses = new DAL.Expenses() { MonthId = Month, YearId = Year };
            ViewData["ExpenseTypeId"] = new SelectList(await _repoWrapper.ExpenseTypes.GetAll(), "ExpenseTypePk", "ExpenseType");
            ViewData["MonthId"] = new SelectList(await _repoWrapper.Months.GetAll(), "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.GetAll(), "YearPk", "YearPk");
            return Page();
        }

        [BindProperty]
        public DAL.Expenses Expenses { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _repoWrapper.Expenses.Add(Expenses);
            await _repoWrapper.SaveChanges();

            return RedirectToPage("./Index", new { Month = Expenses.MonthId, Year = Expenses.YearId });
        }
    }
}