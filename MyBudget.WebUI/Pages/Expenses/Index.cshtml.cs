﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBudget.DAL;

namespace MyBudget.WebUI.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public IndexModel(MyBudgetContext context)
        {
            _context = context;
        }

        public IList<DAL.Expenses> Expenses { get;set; }


        public void OnGet()
        {

            Expenses = _context.Expenses
                .Include(e => e.ExpenseType)
                .Include(e => e.Month)
                .Include(e => e.Year).ToList();
        }
    }
}
