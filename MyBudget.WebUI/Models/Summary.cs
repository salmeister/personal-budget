using MyBudget.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.WebUI.Models
{
    public class Summary
    {
        
        public int Year { get; set; }
        public Months Month { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Expenses { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Payments { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Income { get; set; }
    }
}
