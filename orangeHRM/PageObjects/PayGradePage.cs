using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class PayGrade : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "payGrade_name")]
        [CacheLookup]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "payGradeCurrency_currencyName")]
        [CacheLookup]
        private IWebElement Currency { get; set; }

        [FindsBy(How = How.Id, Using = "payGradeCurrency_minSalary")]
        [CacheLookup]
        private IWebElement MinSalary { get; set; }

        [FindsBy(How = How.Id, Using = "payGradeCurrency_maxSalary")]
        [CacheLookup]
        private IWebElement MaxSalary { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveCurrency")]
        [CacheLookup]
        private IWebElement SaveCurrencyBtn { get; set; }

        [FindsBy(How = How.Id, Using = "cancelButton")]
        [CacheLookup]
        private IWebElement CancelCurrencyBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddCurrency")]
        [CacheLookup]
        public IWebElement AddCurrencyBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        public IWebElement EditBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnDeleteCurrency")]
        [CacheLookup]
        public IWebElement DeleteCurrencyBtn { get; set; }

        #endregion

        public class AssignedCurrencies
        {
            internal static void AssignCurrency(string payGrade, string currency, decimal minSalary = 0.00m, decimal maxSalary = 0.00m)
            {
                _logger.Info("Entering AssignCurrency().");

                try
                {
                    // Locate the pay grade
                    int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(payGrade, "resultTable");

                    Pages.PayGrade._driver.FindElement(By.LinkText(payGrade)).Click();

                    // Add currency section
                    Pages.PayGrade.AddCurrencyBtn.Click();
                    Pages.PayGrade.Currency.Clear();
                    Pages.PayGrade.Currency.SendKeys(currency + Keys.ArrowLeft + Keys.Tab);
                    Pages.PayGrade.MinSalary.Clear();
                    Pages.PayGrade.MinSalary.SendKeys(minSalary + Keys.Tab);
                    Pages.PayGrade.MaxSalary.Clear();
                    Pages.PayGrade.MaxSalary.SendKeys(maxSalary + Keys.Tab);
                    Pages.PayGrade.SaveCurrencyBtn.Click();
                }
                catch
                {
                    throw new Exception($"Unable to add currency: {currency} to pay grade {payGrade}");
                }
                finally
                {
                    _logger.Info("Exiting AssignCurrency().");
                }
   
            }

            internal static bool? CurrencyCorrectlyAssigned(string payGrade, string currency, decimal minSalary, decimal maxSalary)
            {
                _logger.Info("Entering CurrencyCorrectlyAdded().");

                // strip off the abbreviation text so that a match can be made with what is in table
                currency = CorrectString(currency);

                //Build an array of data used to run extracted data against
                string[] currencyData = new string[] { "", currency, minSalary.ToString("N2"), maxSalary.ToString("N2") };

                try
                {
                    _logger.Info("Getting index of row containing pay grade.");

                    int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(currency, "tblCurrencies");
                    // Getting the elements in the row
                    IList<IWebElement> TableData = Pages.PayGrade._driver.FindElements(By.XPath($"//tbody/tr[{payGradeRow}]/td"));

                    //Build a list of extracted elements from table
                    List<string> items = new List<string>();
                    foreach (IWebElement item in TableData)
                    {
                        if ((item.Text != "") || (item.Text != null))
                            items.Add(item.Text);
                    }
                    return Enumerable.SequenceEqual(items, currencyData);
                }
                catch
                {
                    _logger.Info("The Currency was not added correctly.");
                    return false;
                }
                finally
                {
                    _logger.Info("Exiting CurrencyCorrectlyAdded().");
                }
            }

            internal static bool? CurrencyCorrectlyDeleted(string payGrade, string currency)
            {
                _logger.Info("Entering CurrencyCorrectlyDeleted().");
                try
                {
                    // strip off the abbreviation text so that a match can be made with what is in table
                    currency = CorrectString(currency);

                    int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(payGrade, "resultTable");

                    // Find the pay grade record
                    Pages.PayGrade._driver.FindElement(By.LinkText(payGrade)).Click();

                    int jobTitleRow = Pages.PayGrade.SearchForRowContainingRecord(currency, "tblCurrencies");
                    return false;
                }
                catch
                {
                    return true;
                }
                finally
                {
                    _logger.Info("Exiting CurrencyCorrectlyDeleted().");
                }
            }

            internal static void DeleteAssignedCurrency(string payGrade, string currency)
            {
                _logger.Info("Entering DeleteAssignedCurrency().");

                try
                {
                    // strip off the abbreviation text so that a match can be made with what is in table
                    currency = CorrectString(currency);

                    int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(payGrade, "resultTable");

                    // Find the pay grade record
                    Pages.PayGrade._driver.FindElement(By.LinkText(payGrade)).Click();

                    // Find the currency record
                    int currencyRow = Pages.OrangeHRM.SearchForRowContainingRecord(currency, "tblCurrencies");

                    Pages.PayGrade._driver.FindElement(By.XPath($"//tbody/tr[{currencyRow}]/td")).Click();
                    Pages.PayGrade.DeleteCurrencyBtn.Click();

                }
                catch
                {
                    throw new Exception($"The expected Pay Grade/Assigned Currency: {payGrade}/{currency} could not be found!");
                }
                finally
                {
                    _logger.Info("Exiting DeleteAssignedCurrency().");
                }
               
            }

            internal static void EditAssignedCurrency(string payGrade, string currency, string newCurrency, decimal newMinSalary, decimal newMaxSalary)
            {
                _logger.Info("Entering EditAssignedCurrency().");
                try
                {
                    // strip off the abbreviation text so that a match can be made with what is in table
                    currency = CorrectString(currency);

                    int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(payGrade, "resultTable");

                    // Find the pay grade record to edit
                    Pages.PayGrade._driver.FindElement(By.LinkText(payGrade)).Click();

                    // Find the assigned currency to edit
                    Pages.PayGrade._driver.FindElement(By.LinkText(currency)).Click();

                    // Make the correction to the pay grade
                    Pages.PayGrade.Currency.Clear();
                    Pages.PayGrade.Currency.SendKeys(newCurrency + Keys.ArrowLeft + Keys.Tab);
                    Pages.PayGrade.MinSalary.Clear();
                    Pages.PayGrade.MinSalary.SendKeys(newMinSalary + Keys.Tab);
                    Pages.PayGrade.MaxSalary.Clear();
                    Pages.PayGrade.MaxSalary.SendKeys(newMaxSalary + Keys.Tab);
                    Pages.PayGrade.SaveCurrencyBtn.Click();
                }
                catch
                {
                    throw new Exception($"The expected Pay Grade/Assigned Currency: {payGrade}/{currency} could not be found!");
                }
                finally
                {
                    _logger.Info("Exiting EditAssignedCurrency().");
                }
            }
        }

        internal static void AddPayGrade(string payGrade)
        {
            _logger.Info("Entering AddPayGrade().");

            Pages.PayGrade.AddBtn.Click();
            Pages.PayGrade.Name.Clear();
            Pages.PayGrade.Name.SendKeys(payGrade);
            Pages.PayGrade.SaveBtn.Click();
            Menu.Admin.Job.PayGrades.GoTo();

            _logger.Info("Exiting AddPayGrade().");
        }

        internal static void EditPayGrade(string originalPayGrade, string correctedPayGrade)
        {
            _logger.Info("Entering EditPayGrade().");
            try
            {
                int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(originalPayGrade, "resultTable");

                // Find the record to edit
                Pages.PayGrade._driver.FindElement(By.LinkText(originalPayGrade)).Click();

                Pages.PayGrade.EditBtn.Click();

                // Make the correction to the pay grade
                Pages.PayGrade.Name.Clear();
                Pages.PayGrade.Name.SendKeys(correctedPayGrade);

                Pages.PayGrade.SaveBtn.Click();
            }
            catch
            {
                throw new Exception($"The expected Pay Grade: {originalPayGrade} could not be found!");
            }
            finally
            {
                _logger.Info("Exiting EditPayGrade().");
            }
        }

        internal static void DeletePayGrade(string payGrade)
        {
            _logger.Info("Entering DeletePayGrade().");

            try
            {
                // Locate the pay grade
                int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(payGrade, "resultTable");

                Pages.PayGrade._driver.FindElement(By.XPath($"//tbody/tr[{payGradeRow}]/td")).Click();
                Pages.PayGrade.DeleteBtn.Click();
                
                // Respond to confirmation dialog
                Pages.Dialog.OkButton.Click();
            }
            catch
            {
                throw new Exception($"The expected Pay Grade: {payGrade} could not be found!");
            }
            finally
            {
                _logger.Info("Exiting DeletePayGrade().");
            }
        }

        internal static bool? PayGradeCorrectlyAssigned(string payGrade)
        {
            _logger.Info("Entering PayGradeCorrectlyAdded().");
            
            //Build an array of data used to run extracted data against
            string[] payGradeData = new string[] { "", payGrade, ""  };

            try
            {
                _logger.Info("Getting index of row containing pay grade.");

                int payGradeRow = Pages.OrangeHRM.SearchForRowContainingRecord(payGrade, "resultTable");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.PayGrade._driver.FindElements(By.XPath($"//tbody/tr[{payGradeRow}]/td"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in TableData)
                {
                    if ((item.Text != "") || (item.Text != null))
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, payGradeData);
            }
            catch
            {
                _logger.Info("The Pay Grade was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting PayGradeCorrectlyAdded().");
            }
        }

        internal static bool? PayGradeCorrectlyDeleted(string payGrade)
        {
            _logger.Info("Entering PayGradeCorrectlyDeleted().");
            try
            {
                int jobTitleRow = Pages.PayGrade.SearchForRowContainingRecord(payGrade, "resultTable");
                return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                _logger.Info("Exiting PayGradeCorrectlyDeleted().");
            }
        }

        private static string CorrectString(string currency)
        {
            string temp1 = currency.Remove(6);
            string temp2 = currency.Replace(temp1, "");
            return temp2;
        }
    }
}