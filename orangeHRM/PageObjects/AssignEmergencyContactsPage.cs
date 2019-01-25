using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrangeHRM.PageObjects
{
    public class AssignEmergencyContacts : EmployeeList
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private IWebDriver _driver = BrowserFactory.Driver;

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "btnAddContact")]
        [CacheLookup]
        public new IWebElement AddBtn { get; set; }

        [FindsBy(How = How.Id, Using = "DelContactsBtn")]
        [CacheLookup]
        public new IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveEContact")]
        [CacheLookup]
        public new IWebElement SaveBtn { get; set; }
        #endregion

        public void AddEmergencyContact(string name, string relationship, string homePhone = null, string mobilePhone=null, string workPhone=null)
        {
            _logger.Info($"AddEmergencyContact called with: Name: {name}, Relationship: {relationship}, HomePhone: {homePhone}, MobilePhone: {mobilePhone} and WorkPhone: {workPhone}");
            AddBtn.Click();

            _driver.FindElement(By.Id("emgcontacts_name")).SendKeys(name);
            _driver.FindElement(By.Id("emgcontacts_relationship")).SendKeys(relationship);
            // One of these elements is required
            _driver.FindElement(By.Id("emgcontacts_homePhone")).SendKeys(homePhone);
            _driver.FindElement(By.Id("emgcontacts_mobilePhone")).SendKeys(mobilePhone);
            _driver.FindElement(By.Id("emgcontacts_workPhone")).SendKeys(workPhone);

            _logger.Info("Clicking Save Button.");
            SaveBtn.Click(); // Save contact
        }

        public IWebElement SearchForEmergencyContact(string emergencyContact)
        {
            _logger.Info($"SearchForEmergencyContact called with: {emergencyContact}.");
            Table w3cTable = new Table(_driver.FindElement(By.Id("emgcontact_list")));
            _logger.Info("Locating the Emergency Contact table.");
            try
            {
                IWebElement emergencyContactRow = w3cTable.FindRowMatchingColumnData("Name", emergencyContact);
                _logger.Info("Emergency Contact found.");
                return emergencyContactRow;
            }
            catch
            {
                _logger.Info("Emergency Contact was not found.");
                throw new Exception($"The Emergency Contact: {emergencyContact} was not found.");
            }
            
        }

        public static bool EmergencyContactCorrectlyAdded(string name, string relationship, string homePhone = "", string mobilePhone = "", string workPhone = "")
        {
            _logger.Info("Entering EmergencyContactCorrectlyAdded().");

            try
            {
                _logger.Info("Getting index of row containing Immigration Record.");

                // Need to get number in rows to handle dynamic element in form
                Table w3cTable = new Table(Pages.AssignEmergencyContacts._driver.FindElement(By.Id("emgcontact_list")));
                int numEmContacts = w3cTable.RowCount();

                // Use rowCount in array
                string[] EmergencyContactData = new string[] { name, numEmContacts.ToString(), relationship, homePhone, mobilePhone, workPhone };

                // Find the row containing the Emergency Contact
                int emContactRow = Pages.AssignEmergencyContacts.SearchForRowContainingRecord(name, "emgcontact_list");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.AssignEmergencyContacts._driver.FindElements(By.XPath($"//tbody/tr[{emContactRow}]/input[@type='hidden']"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                items.Add(Pages.AssignEmergencyContacts._driver.FindElements(By.ClassName("emgContactName"))[emContactRow].Text);
                foreach (IWebElement item in TableData)
                {
                    items.Add(item.GetAttribute("value"));
                }
                //compare the two data sets and return true if they are equal
                return Enumerable.SequenceEqual(items, EmergencyContactData);
            }
            catch
            {
                _logger.Info("The Emergency Contact was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting EmergencyContactCorrectlyAdded().");
            }
        }
        /*
        public int SearchForRowContainingRecord(string searchCriteria, string tableNameID)
        {
            _logger.Info("Entering SearchForRow()");
            Table w3cTable = new Table(_driver.FindElement(By.Id(tableNameID)));
            _logger.Info($"Locating the {tableNameID} table.");
            try
            {
                int tableRow = w3cTable.FindFirstRowIndexByKnownValue(searchCriteria);
                _logger.Info($"Row containing {searchCriteria} found.");
                return tableRow;
            }
            catch
            {
                _logger.Info($"The Row containing {searchCriteria} was not found.");
                throw new Exception($"The Row containing {searchCriteria} was not found.");
            }
        }*/
    }
}