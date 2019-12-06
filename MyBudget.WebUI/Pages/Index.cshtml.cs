using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL.Repositories;
using MyBudget.WebUI.Models;

namespace MyBudget.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRepositoryWrapper _repoWrapper;

        //Constructor
        public IndexModel(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        //Model
        public IList<Summary> Summaries { get; set; }
        public int Year { get; set; }


        public async Task OnGet(int? Year)
        {
            await GetYearData(Year);

            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.Get(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");

        }

        public async Task OnPost(int? Year)
        {
            await GetYearData(Year);

            ViewData["YearId"] = new SelectList(await _repoWrapper.Years.Get(y => y.YearPk >= 2005 && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");

        }

        public async Task GetYearData(int? Year)
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
                    Month = (await _repoWrapper.Months.Get(x => x.MonthPk == m)).FirstOrDefault(),
                    Expenses = (await _repoWrapper.Expenses.GetAll()).Where(p => p.MonthId == m && p.YearId == Year).Sum(p => p.Amount) ?? 0,
                    Payments = (await _repoWrapper.Payments.GetAll()).Where(p => p.MonthId == m && p.YearId == Year).Sum(p => p.Amount),
                    Income = (await _repoWrapper.Income.GetAll()).Where(p => p.MonthId == m && p.YearId == Year).Sum(p => p.Amount) ?? 0,
                });

            }
        }


    }
}