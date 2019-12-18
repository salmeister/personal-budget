using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBudget.DAL;
using MyBudget.Domain.Imports;

namespace MyBudget.WebUI.Pages
{
    public class ImportModel : PageModel
    {
        private readonly MyBudgetContext _context;
        private IWebHostEnvironment _environment;
        private readonly string importFolder = "imports";

        //Model
        [BindProperty]
        public int Month { get; set; }
        [BindProperty]
        public int Year { get; set; }
        [BindProperty]
        public bool Preview { get; set; }
        [BindProperty]
        public IFormFile CheckingFile { get; set; }
        [BindProperty]
        public IFormFile CreditFile { get; set; }
        public string Result { get; set; }


        public ImportModel(MyBudgetContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public void OnGet()
        {
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(_context.Years.Where(y => y.YearPk >= DateTime.Now.AddYears(-1).Year && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");
        }

        public async Task<IActionResult> OnPostAsync(int Month, int Year, bool Preview)
        {
            ViewData["MonthId"] = new SelectList(_context.Months, "MonthPk", "MonthAbbr");
            ViewData["YearId"] = new SelectList(_context.Years.Where(y => y.YearPk >= DateTime.Now.AddYears(-1).Year && y.YearPk <= DateTime.Now.Year), "YearPk", "YearPk");

            CleanImportDir();
            //Checking File
            var checkingFile = Path.Combine(_environment.ContentRootPath, importFolder, CheckingFile.FileName);
            using (var fileStream = new FileStream(checkingFile, FileMode.Create))
            {
                await CheckingFile.CopyToAsync(fileStream);
            }
            //Credit File
            var creditFile = Path.Combine(_environment.ContentRootPath, importFolder, CreditFile.FileName);
            using (var fileStream = new FileStream(creditFile, FileMode.Create))
            {
                await CreditFile.CopyToAsync(fileStream);
            }
            //Do Import
            USBImport importer = new USBImport(_context, Month, Year, checkingFile, creditFile);
            Result = importer.Import(Preview);
            CleanImportDir();

            return Page();
        }

        private void CleanImportDir()
        {
            string serverPath = Path.Combine(_environment.ContentRootPath, importFolder);
            if (!(Directory.Exists(serverPath)))
            {
                Directory.CreateDirectory(serverPath);
            }
            DirectoryInfo importDir = new DirectoryInfo(serverPath);
            var files = importDir.GetFiles();
            foreach (var file in files)
            {
                System.IO.File.Delete(file.FullName);
            }
        }
    }
}