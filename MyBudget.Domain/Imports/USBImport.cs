using Microsoft.VisualBasic.FileIO;
using MyBudget.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using MyBudget.DAL.Repositories;

namespace MyBudget.Domain.Imports
{
    public class USBImport
    {
        private readonly int _month;
        private readonly int _year;
        private readonly string _checkingFile;
        private readonly string _creditFile;
        static IRepositoryWrapper _repoWrapper;

        ///////////////////
        //Globals
        ///////////////////
        private decimal household_goods = 0;
        private decimal groceries = 0;
        private decimal home_improvements = 0;
        private decimal gym_member = 0;
        private decimal gasoline = 0;
        private decimal cell = 0;
        private decimal auto_care = 0;
        private decimal mortgage = 0;
        private decimal cable_internet = 0;
        private decimal gas = 0;
        private decimal electric = 0;
        private decimal water = 0;
        private decimal garbage = 0;
        private decimal car_ins1 = 0;
        private decimal car_ins2 = 0;
        private decimal umbrella_ins = 0;
        private decimal katie_life_ins = 0;
        private decimal andy_life_ins = 0;
        private Dictionary<DateTime, decimal> usb = new Dictionary<DateTime, decimal>();
        private Dictionary<DateTime, decimal> bes = new Dictionary<DateTime, decimal>();

        public USBImport(IRepositoryWrapper repoWrapper, int month, int year, string checkingFile, string creditFile)
        {
            _repoWrapper = repoWrapper;
            _month = month;
            _year = year;
            _checkingFile = checkingFile;
            _creditFile = creditFile;
        }

        public async Task<string> Import(bool preview)
        {
            ProcessCredit();
            ProcessChecking();

            if (preview)
            {
                return GenerateHTMLPreview();
            }
            else
            {
                await AddExpenses();
                await AddPayments();
                await AddIcome();

                return $"<p>{_month.ToString()}-{_year.ToString()} imported.</p>";
            }
        }

        private string GenerateHTMLPreview()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<table style=\"text-align: right;\">");
            sb.Append("<tr><td>Mortgage</td><td>" + mortgage + "</td></tr>");
            sb.Append("<tr><td>Household goods (Target,Walmart,etc.)</td><td>" + household_goods + "</td></tr>");
            sb.Append("<tr><td>Groceries</td><td>" + groceries + "</td></tr>");
            sb.Append("<tr><td>Home Improvements (Home Depot,Menards,etc.)</td><td>" + home_improvements + "</td></tr>");
            sb.Append("<tr><td>Gasoline</td><td>" + gasoline + "</td></tr>");
            sb.Append("<tr><td>Gym Membership</td><td>" + gym_member + "</td></tr>");
            sb.Append("<tr><td>Auto Care</td><td>" + auto_care + "</td></tr>");
            sb.Append("<tr><td>Cable and Internet</td><td>" + cable_internet + "</td></tr>");
            sb.Append("<tr><td>Gas</td><td>" + gas + "</td></tr>");
            sb.Append("<tr><td>Electric</td><td>" + electric + "</td></tr>");
            sb.Append("<tr><td>Cell phone</td><td>" + cell + "</td></tr>");
            sb.Append("<tr><td>Water</td><td>" + water + "</td></tr>");
            sb.Append("<tr><td>Garbage</td><td>" + garbage + "</td></tr>");
            if (car_ins1 > 0 || car_ins2 > 0)
            {
                sb.Append("<tr><td>Car insurance 1</td><td>" + car_ins1 + "</td></tr>");
                sb.Append("<tr><td>Car insurance 2</td><td>" + car_ins2 + "</td></tr>");
            }
            if (umbrella_ins > 0)
            {
                sb.Append("<tr><td>Umbrella insurance</td><td>" + umbrella_ins + "</td></tr>");
            }
            if (katie_life_ins > 0)
            {
                sb.Append("<tr><td>Katie life insurance</td><td>" + katie_life_ins + "</td></tr>");
            }
            if (andy_life_ins > 0)
            {
                sb.Append("<tr><td>Andy life insurance</td><td>" + andy_life_ins + "</td></tr>");
            }
            foreach (KeyValuePair<DateTime, decimal> usbPaycheck in usb)
            {
                sb.Append("<tr><td>USB paycheck</td><td>" + usbPaycheck.Value + "</td></tr>");
            }
            foreach (KeyValuePair<DateTime, decimal> besPaycheck in bes)
            {
                sb.Append("<tr><td>BES paycheck</td><td>" + besPaycheck.Value + "</td></tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }

        private async Task AddIcome()
        {
            var incomeSources = _repoWrapper.IncomeSources.GetAll().Result;
            var familyMembers = _repoWrapper.FamilyMembers.GetAll().Result;


            if (usb.Count > 0)
            {
                Income income = new Income();

                foreach (KeyValuePair<DateTime, decimal> usbPaycheck in usb)
                {
                    var incomeSource = incomeSources.Where(i => i.IncomeSourceAcro.ToUpper() == "USB").FirstOrDefault();
                    var familyMember = familyMembers.Where(f => f.FirstName.ToUpper() == "ANDY").FirstOrDefault();
                    await _repoWrapper.Income.Add(new Income() { Amount = usbPaycheck.Value, ReceivedDate = usbPaycheck.Key, FamilyMemberId = familyMember.FamilyMemberPk, IncomeSourceId = incomeSource.IncomeSourcePk, MonthId = _month, YearId = _year });
                }
            }

            if (bes.Count > 0)
            {
                Income income = new Income();

                foreach (KeyValuePair<DateTime, decimal> besPaycheck in bes)
                {
                    var incomeSource = incomeSources.Where(i => i.IncomeSourceAcro.ToUpper() == "BES").FirstOrDefault();
                    var familyMember = familyMembers.Where(f => f.FirstName.ToUpper() == "KATIE").FirstOrDefault();
                    await _repoWrapper.Income.Add(new Income() { Amount = besPaycheck.Value, ReceivedDate = besPaycheck.Key, FamilyMemberId = familyMember.FamilyMemberPk, IncomeSourceId = incomeSource.IncomeSourcePk, MonthId = _month, YearId = _year });
                }
            }
        }

        private async Task AddPayments()
        {
            var loans = _repoWrapper.Loans.GetAll().Result;
            var insurance = _repoWrapper.Insurance.GetAll().Result;

            if (mortgage > 0)
            {
                var loan = loans.Where(l => l.LoanAlias.ToUpper() == "LOUISIANA AVE").FirstOrDefault();
                await _repoWrapper.Payments.Add(new Payments() { Amount = mortgage, LoanId = loan.LoanPk, MonthId = _month, YearId = _year });
            }
            if (umbrella_ins > 0)
            {
                var insur = insurance.Where(i => i.InsuranceAlias.ToUpper() == "UMBRELLA").FirstOrDefault();
                await _repoWrapper.Payments.Add(new Payments() { Amount = umbrella_ins, InsuranceId = insur.InsurancePk, MonthId = _month, YearId = _year });
            }
            if (car_ins1 > 0)
            {
                var insur = insurance.Where(i => i.InsuranceAlias.ToUpper() == "CARAVAN").FirstOrDefault();
                await _repoWrapper.Payments.Add(new Payments() { Amount = car_ins1, InsuranceId = insur.InsurancePk, MonthId = _month, YearId = _year });
            }
            if (car_ins2 > 0)
            {
                var insur = insurance.Where(i => i.InsuranceAlias.ToUpper() == "RAM").FirstOrDefault();
                await _repoWrapper.Payments.Add(new Payments() { Amount = car_ins2, InsuranceId = insur.InsurancePk, MonthId = _month, YearId = _year });
            }
            if (katie_life_ins > 0)
            {
                var insur = insurance.Where(i => i.InsuranceAlias.ToUpper() == "KATIE-LIFE").FirstOrDefault();
                await _repoWrapper.Payments.Add(new Payments() { Amount = katie_life_ins, InsuranceId = insur.InsurancePk, MonthId = _month, YearId = _year });
            }
            if (andy_life_ins > 0)
            {
                var insur = insurance.Where(i => i.InsuranceAlias.ToUpper() == "ANDY-LIFE").FirstOrDefault();
                await _repoWrapper.Payments.Add(new Payments() { Amount = andy_life_ins, InsuranceId = insur.InsurancePk, MonthId = _month, YearId = _year });
            }
        }

        private async Task AddExpenses()
        {
            var expenseTypes = _repoWrapper.ExpenseTypes.GetAll().Result;

            if (gasoline > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "GASOLINE").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = gasoline, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }

            if (household_goods > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "HOUSEHOLD GOODS").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = household_goods, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (groceries > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "GROCERIES").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = groceries, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }

            if (home_improvements > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "HOME IMPROVEMENTS").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = home_improvements, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }

            if (gym_member > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "GYM").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = gym_member, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (cell > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "CELL PHONE").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = cell, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (cable_internet > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "INTERNET").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = cable_internet, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (gas > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "NATURAL GAS").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = gas, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (electric > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "ELECTRICAL").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = electric, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (water > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "WATER").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = water, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (garbage > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "GARBAGE  ").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = garbage, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
            if (auto_care > 0)
            {
                var type = expenseTypes.Where(e => e.ExpenseType.ToUpper() == "AUTO CARE").FirstOrDefault();
                await _repoWrapper.Expenses.Add(new Expenses() { Amount = auto_care, ExpenseTypeId = type.ExpenseTypePk, MonthId = _month, YearId = _year });
            }
        }

        private void ProcessChecking()
        {
            int month = 0;
            int day = 0;
            int year = 0;
            decimal amount = 0;
            string desc = "";
            string memo = "";

            StreamReader srChecking = File.OpenText(_checkingFile);
            srChecking.ReadLine(); //strip header
            using (TextFieldParser parser = new TextFieldParser(srChecking))
            {
                parser.TrimWhiteSpace = true;
                parser.Delimiters = new[] { "," };
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length > 0)
                    {
                        string[] date = fields[0].Split('/');
                        month = Convert.ToInt32(date[0]);
                        day = Convert.ToInt32(date[1]);
                        year = Convert.ToInt32(date[2]);
                        if (fields[4].StartsWith("-"))
                        {
                            amount = Math.Abs(Convert.ToDecimal(fields[4]));
                        }
                        else
                        {
                            amount = Convert.ToDecimal(fields[4]) * -1;
                        }
                        desc = fields[2].ToUpper();
                        memo = fields[3].ToUpper();

                        if (_month == month && _year == year)
                        {
                            if ((memo.Contains("US BANK HOME MTG")))
                            {
                                mortgage += amount;
                            }
                            if (desc.Contains(" MEDIACOM") || desc.Contains(" CHARTER COMM"))
                            {
                                cable_internet += amount;
                            }
                            if ((desc.Contains("ELECTRONIC DEPOSIT US BANK NAT")))
                            {
                                amount = (amount * -1) + 100;
                                usb.Add(new DateTime(year, month, day), amount);
                            }
                            if ((desc.Contains("ELECTRONIC DEPOSIT IND SD 191")))
                            {
                                bes.Add(new DateTime(year, month, day), amount * -1);
                            }
                            if ((desc.Contains("CTRPT ENGY")))
                            {
                                gas += amount;
                            }
                            if (desc.Contains("DAKOTA ELEC") || desc.Contains("PMT MINNESOTA VALLEY"))
                            {
                                electric += amount;
                            }
                            if ((memo.Contains(" CITY OF SAVAGE")))
                            {
                                water += amount;
                            }
                            if ((desc.Contains("DICKS SANITATION")))
                            {
                                garbage += amount;
                            }
                            if ((desc.Contains(" PMT DISCOVER CARD")) || (desc.Contains(" PMT TARGET")) || (desc.Contains(" ALDI ")))
                            {
                                household_goods += amount;
                            }
                            if (desc.Contains("HORACE MANN INS"))
                            {
                                if (amount == (decimal)148.75)
                                {
                                    katie_life_ins += amount;
                                }
                                else
                                {
                                    umbrella_ins += amount;
                                }
                            }
                            if (desc.Contains("PRINCIPAL LIFE"))
                            {
                                if (amount == (decimal)340)
                                {
                                    katie_life_ins += amount;
                                }
                                if (amount == (decimal)460)
                                {
                                    andy_life_ins += amount;
                                }
                            }
                        }
                    }
                }
            }
            srChecking.Close();
            srChecking.Dispose();
        }

        private void ProcessCredit()
        {
            int month = 0;
            int day = 0;
            int year = 0;
            decimal amount = 0;
            string desc = "";
            string memo = "";

            ///////////////////
            //Credit Card
            ///////////////////
            StreamReader srCredit = File.OpenText(_creditFile);
            srCredit.ReadLine(); //strip header
            using (TextFieldParser parser = new TextFieldParser(srCredit))
            {
                parser.TrimWhiteSpace = true;
                parser.Delimiters = new[] { "," };
                parser.HasFieldsEnclosedInQuotes = true;

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length > 0)
                    {
                        string[] date = fields[0].Split('/');
                        month = Convert.ToInt32(date[0]);
                        day = Convert.ToInt32(date[1]);
                        year = Convert.ToInt32(date[2]);
                        if (fields[4].StartsWith("-"))
                        {
                            amount = Math.Abs(Convert.ToDecimal(fields[4]));
                        }
                        else
                        {
                            amount = Convert.ToDecimal(fields[4]) * -1;
                        }
                        desc = fields[2].ToUpper();

                        if (_month == month && _year == year)
                        {
                            if ((desc.Contains("TARGET")) || (desc.Contains("WAL-MART")) || (desc.Contains("WM SUPERCENTER")) || (desc.Contains("SHOPKO")) || (desc.Contains("WALMART")) || (desc.Contains("SAMSCLUB")) || (desc.Contains("SAMS CLUB")) || (desc.Contains("ALDI ")))
                            {
                                household_goods += amount;
                            }
                            if ((desc.Contains("RAINBOW FOODS")) || (desc.Contains("CUB FOODS")) || (desc.Contains("HYVEE FOOD")) || (desc.Contains("HY VEE")) || (desc.Contains("KOWALSKI'S")) || (desc.Contains("BYERLY'S")) || (desc.Contains("LUNDS")))
                            {
                                groceries += amount;
                            }
                            if ((desc.Contains("MILLS FLEET FARM")) || (desc.Contains("ACE HARDWARE")) || (desc.Contains("THE HOME DEPOT")) || (desc.Contains("MENARDS")) || (desc.Contains("LOWES")))
                            {
                                home_improvements += amount;
                            }
                            if (desc.Contains("YMCA") || desc.StartsWith("SNAP FITNESS") || desc.Contains("SNAP PRIOR LAKE 519") || desc.Contains("LIFE TIME MO DUES"))
                            {
                                gym_member += amount;
                            }
                            if ((desc.Contains("SPEEDWAY")) || (desc.Contains("CEDAR AVE TIRE")) || (desc.Contains("SAMSCLUB 6311 GAS")) || (desc.Contains("SHELL OIL")) || (desc.Contains("KWIK TRIP")) || (desc.Contains("CASEYS")) || (desc.Contains("MILLS GAS")) || (desc.Contains("MARATHON OIL")) || (desc.Contains("MARATHON PETRO")) || (desc.Contains("SUPERAMERICA")) || (desc.Contains("AMOCO OIL")) || (desc.Contains("HOLIDAY ST")) || (desc.Contains("AUTO (GAS)")) || (desc.Contains("EXXON")) || (desc.Contains("QUICK STOP")) || (desc.Contains("M & H")) || (desc.Contains("KUM & GO")) || (desc.Contains("BP OIL")) || (desc.Contains("HWY 13 BP")) || (desc.Contains("EXPRESSWAY")) || (desc.Contains(" OASIS ")) || (desc.Contains("FLEET FARM GAS")) || (desc.Contains(" AMOCO ")) || (desc.Contains("CUB FUEL ")) || (desc.StartsWith("HY VEE GAS ")) || (desc.StartsWith("MURPHY6795")) || (desc.Contains("MOTORMART") || desc.Contains("SHAKOPEE DAKOTA CONV")))
                            {
                                gasoline += amount;
                            }
                            if ((desc.Contains("CHECKER")) || (desc.Contains("MR TIRE")) || (desc.Contains("OREILLY")) || (desc.Contains("VALLEY AUTO")))
                            {
                                auto_care += amount;
                            }
                            if ((desc.Contains("HORACE MANN *INSURANCE")))
                            {
                                car_ins1 += Math.Round((amount / 2), 2);
                                car_ins2 += Math.Round((amount / 2), 2);
                            }
                            if ((desc.Contains("MEDIACOM")))
                            {
                                cable_internet += amount;
                            }
                            if ((desc.Contains("SPRINT *WIRELESS")))
                            {
                                cell += amount;
                            }
                        }
                    }

                }
            }
            srCredit.Close();
            srCredit.Dispose();
        }
    }
}
