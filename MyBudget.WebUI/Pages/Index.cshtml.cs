using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;
using MyBudget.WebUI.Models;

namespace MyBudget.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MyBudgetContext _context;

        public IndexModel(MyBudgetContext context)
        {
            _context = context;
        }

        //Model
        public IList<Summary> Summaries { get; set; }
        public int Year { get; set; }


        public void OnGet(int? Year)
        {
            GetYearData(Year);

            ViewData["YearId"] = new SelectList(_context.Years.Where(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");

        }

        public void OnPost(int? Year)
        {
            GetYearData(Year);

            ViewData["YearId"] = new SelectList(_context.Years.Where(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");

        }

        public void GetYearData(int? Year)
        {
            Summaries = new List<Summary>();

            DateTime today = DateTime.Now;
            if (Year is null)
            {
                Year = today.Year;
            }
            this.Year = Year.Value;

            int endMonth = 12;
            if (Year == today.Year)
            {
                endMonth = today.Month;
            }

            for (int m = 1; m <= endMonth; m++)
            {
                Summaries.Add(new Summary()
                {
                    Year = Year.Value,
                    Month = _context.Months.Where(x => x.MonthPk == m).FirstOrDefault(),
                    Expenses = _context.Expenses.Where(p => p.MonthId == m && p.YearId == Year).Sum(p => p.Amount) ?? 0,
                    Payments = _context.Payments.Where(p => p.MonthId == m && p.YearId == Year).Sum(p => p.Amount),
                    Income = _context.Income.Where(p => p.MonthId == m && p.YearId == Year).Sum(p => p.Amount) ?? 0,
                });

            }
        }


    }
}