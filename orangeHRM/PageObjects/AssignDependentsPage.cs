using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrangeHRM.PageObjects
{
    public class AssignDependent : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "btnAddDependent")]
        [CacheLookup]
        public new IWebElement AddBtn { get; set; }

        [FindsBy(How = How.Id, Using = "delDependentBtn")]
        [CacheLookup]
        public new IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnSaveDependent")]
        [CacheLookup]
        public new IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.Id, Using = "dependent_name")]
        [CacheLookup]
        public IWebElement DependentName { get; set; }

        [FindsBy(How = How.Id, Using = "dependent_relationshipType")]
        [CacheLookup]
        public IWebElement DependentRelationshipType { get; set; }

        [FindsBy(How = How.Id, Using = "dependent_relationship")]
        [CacheLookup]
        public IWebElement DependentRelationship { get; set; }

        [FindsBy(How = How.Id, Using = "dependent_dateOfBirth")]
        [CacheLookup]
        public IWebElement DOB { get; set; }

        #endregion

        internal void AddDependent(string name, string relationship, string other = null, string dob = null)
        {
            _logger.Info("Entering AddDependent()");

            AddBtn.Click();

            DependentName.SendKeys(name);
            DependentRelationshipType.SendKeys(relationship);
            if ((relationship == "Other") || (relationship == "other"))
                DependentRelationship.SendKeys(other);
            DOB.Clear();
            //DOB is not a required field
            DOB.SendKeys(dob + Keys.Tab);

            SaveBtn.Click();
            _logger.Info("Exiting AddDependent()");
        }

        public static bool DependentCorrectlyAdded(string name, string relationship, string other = "", string dob = "")
        {
            _logger.Info("Entering DependentCorrectlyAdded().");
            //Build an array of data used to run extracted data against, note the 1 is there to account for column 1 which is a checkbox
            string[] DependentData = new string[] { name, relationship.ToLower(), other, dob };

            try
            {
                _logger.Info("Getting index of row containing dependent.");
                //int dependentRow = SearchForDependent(name);
                int dependentRow =  Pages.AssignDependent.SearchForRowContainingRecord(name, "dependent_list");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.AssignDependent._driver.FindElements(By.XPath($"//tbody/tr[{dependentRow }]/input[@type='hidden']"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                items.Add(Pages.AssignDependent._driver.FindElements(By.ClassName("dependentName"))[dependentRow].Text);
                foreach (IWebElement item in TableData)
                {
                    items.Add(item.GetAttribute("value"));
                }
                //compare the two data sets and return true if they are equal
                return Enumerable.SequenceEqual(items, DependentData);
            }
            catch
            {
                _logger.Info("The Dependent was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting DependentCorrectlyAdded().");
            }
        }
    }
}
 