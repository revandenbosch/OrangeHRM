using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace OrangeHRM.PageObjects
{
    public class AssignedSalaryComponents : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "addSalary")]
        [CacheLookup]
        public new IWebElement AddBtn { get; set; }
        //private static IWebElement AddBtn = Driver.FindElement(By.Id("addSalary"));

        [FindsBy(How = How.Id, Using = "btnSalarySave")]
        [CacheLookup]
        public new IWebElement SaveBtn { get; set; }
        //private static IWebElement SaveBtn = Driver.FindElement(By.Id("btnSalarySave"));

        [FindsBy(How = How.Id, Using = "salary_sal_grd_code")]
        [CacheLookup]
        public IWebElement PayGrade { get; set; }
        //private static IWebElement PayGrade = Driver.FindElement(By.Id("salary_sal_grd_code"));

        [FindsBy(How = How.Id, Using = "salary_salary_component")]
        [CacheLookup]
        public IWebElement SalaryComponent { get; set; }
        //private static IWebElement SalaryComponent = Driver.FindElement(By.Id("salary_salary_component"));

        [FindsBy(How = How.Id, Using = "salary_payperiod_code")]
        [CacheLookup]
        public IWebElement PayFrequency { get; set; }
        //private static IWebElement PayFrequency = Driver.FindElement(By.Id("salary_payperiod_code"));

        [FindsBy(How = How.Id, Using = "salary_currency_id")]
        [CacheLookup]
        public IWebElement Currency { get; set; }
        //private static IWebElement Currency = Driver.FindElement(By.Id("salary_currency_id"));

        [FindsBy(How = How.Id, Using = "salary_basic_salary")]
        [CacheLookup]
        public IWebElement Amount { get; set; }
        //private static IWebElement Amount = Driver.FindElement(By.Id("salary_basic_salary"));

        [FindsBy(How = How.Id, Using = "salary_comments")]
        [CacheLookup]
        public IWebElement Comments { get; set; }
        //private static IWebElement Comments = Driver.FindElement(By.Id("salary_comments"));

        [FindsBy(How = How.Id, Using = "salary_set_direct_debit")]
        [CacheLookup]
        public IWebElement AddDirectDeposit { get; set; }
        //private static IWebElement AddDirectDeposit = Driver.FindElement(By.Id("salary_set_direct_debit"));

        [FindsBy(How = How.Id, Using = "directdeposit_account")]
        [CacheLookup]
        public IWebElement AccountNumber { get; set; }
        //private static IWebElement AccountNumber = Driver.FindElement(By.Id("directdeposit_account"));

        [FindsBy(How = How.Id, Using = "directdeposit_account_type")]
        [CacheLookup]
        public IWebElement AccountType { get; set; }
        //private static IWebElement AccountType = Driver.FindElement(By.Id("directdeposit_account_type"));

        [FindsBy(How = How.Id, Using = "directdeposit_account_type_other")]
        [CacheLookup]
        public IWebElement OtherAccountType { get; set; }
        //private static IWebElement OtherAccountType = Driver.FindElement(By.Id("directdeposit_account_type_other"));

        [FindsBy(How = How.Id, Using = "directdeposit_routing_num")]
        [CacheLookup]
        public IWebElement RoutingNumber { get; set; }
        //private static IWebElement RoutingNumber = Driver.FindElement(By.Id("directdeposit_routing_num"));

        [FindsBy(How = How.Id, Using = "directdeposit_amount")]
        [CacheLookup]
        public IWebElement DepositAmount { get; set; }
        //private static IWebElement DepositAmount = Driver.FindElement(By.Id("directdeposit_amount"));
        #endregion

        internal static void AddSalary(string payGrade, string salaryComponent, string payFrequency, string currency,
            string amount, string comments, bool directDeposit, string accountNumber, string accountType, string pleaseSpecify, string routingNumber, decimal amountDeposit)
        {
            _logger.Info("Entering AddSalary().");

            WebDriverWait wait = new WebDriverWait(Pages.AssignedSalaryComponents._driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("addSalary")));

            element.Click();

            Pages.AssignedSalaryComponents.PayGrade.SendKeys(payGrade + Keys.Tab);
            Pages.AssignedSalaryComponents.SalaryComponent.SendKeys(salaryComponent);
            Pages.AssignedSalaryComponents.PayFrequency.SendKeys(payFrequency + Keys.Tab);
            Pages.AssignedSalaryComponents.Currency.SendKeys(currency + Keys.Tab);
            Pages.AssignedSalaryComponents.Amount.SendKeys(amount);
            Pages.AssignedSalaryComponents.Comments.SendKeys(comments);


            if (directDeposit)
            {
                Pages.AssignedSalaryComponents.AddDirectDeposit.Click();
                Pages.AssignedSalaryComponents.AccountNumber.SendKeys(accountNumber);
                Pages.AssignedSalaryComponents.AccountType.SendKeys(accountType + Keys.Tab);
                if (accountType == "Other")
                    Pages.AssignedSalaryComponents.OtherAccountType.SendKeys(pleaseSpecify);
                Pages.AssignedSalaryComponents.RoutingNumber.SendKeys(routingNumber);
                Pages.AssignedSalaryComponents.DepositAmount.SendKeys(amountDeposit.ToString());
            }

            //WebDriverWait wait2 = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element2 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("btnSalarySave")));
            element2.Click();
           // SaveBtn.Click();
            _logger.Info("Exiting AddSalary().");
        }

        internal static bool SalaryCorrectlyAdded(string payGrade, string salaryComponent, string currency, string amount, 
            bool directDeposit, string accountNumber, string accountType, string pleaseSpecify, string routingNumber, decimal amountDeposit, string payFrequency = null, string comments = null)
        {
            _logger.Info("Entering SalaryCorrectlyAdded().");
            //Build an array of data used to run extracted data against
            string[] SalaryData = new string[] { salaryComponent, payFrequency, currency, amount, comments };
            string[] DirectDepositData = new string[] { accountNumber, accountType, routingNumber, amountDeposit.ToString() };
            string[] DirectDepositDataOther = new string[] { accountNumber, pleaseSpecify, routingNumber, amountDeposit.ToString()};

            try
            {
                _logger.Info("Getting index of row containing Salary Component.");

                int salCompRow = 1; // SearchForRowContainingRecord(salaryComponent, "tblSalary");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.AssignedSalaryComponents._driver.FindElements(By.XPath($"//tbody/tr[{salCompRow}]/td"));


                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in TableData)
                {
                      if (item.Text != "")
                        items.Add(item.Text);
                }
                
                if (directDeposit)
                {
                    // Locate the Show Direct Deposit Details checkbox
                    Pages.AssignedSalaryComponents._driver.FindElement(By.XPath("//input[@class='chkbox displayDirectDeposit']")).Click();

                    IList<IWebElement> DDData = Pages.AssignedSalaryComponents._driver.FindElements(By.XPath($"//tbody/tr[{salCompRow} + 1]/td/table/tbody/tr/td"));
                    foreach (IWebElement item in DDData)
                    {
                        items.Add(item.Text);
                    }
                    // If Account type is Other then only data is Please Specify is displayed
                    if (accountType == "Other")
                    {
                        return Enumerable.SequenceEqual(items, SalaryData.Concat(DirectDepositDataOther));
                    }
                    // The Account type is not other so use Account type field
                    return Enumerable.SequenceEqual(items, SalaryData.Concat(DirectDepositData));
                }
                else // No direct deposit data was sent
                {
                    //compare the two data sets and return true if they are equal
                    return Enumerable.SequenceEqual(items, SalaryData);
                }               
            }
            catch
            {
                _logger.Info("The Salary Componentt was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting SalaryCorrectlyAdded().");
            }
        }

        internal bool? IsRequiredField(string requiredField)
        {
            _logger.Info("Entering IsRequiredField().");

            string msg = "";
            msg = _driver.FindElement(By.XPath($"//*/li[label[contains(text(), '{requiredField}')]]/span")).Text;
            
            try // Test if element exists
            {
                if (msg == "Required")
                {
                    _logger.Info("Exiting IsRequiredField().");
                    return true;
                }
                else // element text not "Required"
                {
                    _logger.Info("Exiting IsRequiredField().");
                    return false;
                }
            }
            catch // Element not found
            {
                _logger.Info("Exiting IsRequiredField().");
                return false;
            }
            
        }
    }
}