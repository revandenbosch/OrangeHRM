using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OrangeHRM.PageObjects;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Customers : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "addCustomer_customerName")]
        [CacheLookup]
        public IWebElement CustomerName { get; set; }

        [FindsBy(How = How.Id, Using = "addCustomer_description")]
        [CacheLookup]
        public IWebElement Description { get; set; }
        public static object CustomerDescription { get; private set; }
        #endregion

        internal static void AddNewCustomer(string name, string description = "")
        {
            _logger.Info("Entering AddNewCustomer.");

            Pages.Customers.AddBtn.Click();
            Pages.Customers.CustomerName.SendKeys(name);
            Pages.Customers.Description.SendKeys(description);

            Pages.Customers.SaveBtn.Click();
            _logger.Info("Exiting AddNewCustomer.");
        }

        internal static bool? CustomerSuccessfullyAdded(string name, string description = "")
        {

            _logger.Info("Entering CustomerSuccessfullyAdded().");
            //Build an array of data used to run extracted data against
            string[] customerData = new string[] { name, description };

            try
            {
                _logger.Info("Getting index of row containing Customer.");

                int customerRow = Pages.Customers.SearchForRowContainingRecord(name, "resultTable");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.Customers._driver.FindElements(By.XPath($"//tbody/tr[{customerRow}]/td"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in TableData)
                {
                    if (item.Text != "")
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, customerData);
            }
            catch
            {
                _logger.Info("The Customer was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting CustomerSuccessfullyAdded().");
            }
        }

        internal static bool? CustomerSuccessfullyDeleted(string name)
        {
            _logger.Info("Entering CustomerSuccessfullyDeleted().");
            try
            {
                int jobTitleRow = Pages.OrangeHRM.SearchForRowContainingRecord(name, "resultTable");
                return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                _logger.Info("Exiting CustomerSuccessfullyDeleted().");
            }
        }

        internal static void DeleteCustomer(string customerName)
        {
            _logger.Info("Entering DeleteCustomer().");
            try
            {
                // Locate record to delete
                int customerRow = Pages.Customers.SearchForRowContainingRecord(customerName, "resultTable");

                Pages.Customers._driver.FindElement(By.XPath($"//tbody/tr[{customerRow}]/td")).Click();

                Pages.Customers.DeleteBtn.Click();

                Pages.Dialog.OkButton.Click();
            }
            catch
            {
                throw new Exception($"The expected Customer: {customerName} could not be found!");
            }
            finally
            {
                _logger.Info("Exiting DeleteCustomer().");
            }
        }

        internal static bool? IsAlreadyExistsMsg()
        {
            return Pages.Customers._driver.FindElement(By.XPath("//span[contains(text(),'Already exists')]")).Displayed;
        }
    }
}