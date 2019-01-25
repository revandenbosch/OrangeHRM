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
    public class JobTitles : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // Page object definitions
        #region
        //[FindsBy(How = How.Id, Using = "btnAdd")]
        //[CacheLookup]
        //public IWebElement AddBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "editButton")]
        [CacheLookup]
        public IWebElement EditBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnDelete")]
        [CacheLookup]
        public IWebElement DeleteBtn { get; set; }

        [FindsBy(How = How.Id, Using = "jobTitle_jobTitle")]
        [CacheLookup]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.Id, Using = "jobTitle_jobDescription")]
        [CacheLookup]
        public IWebElement JobDescription { get; set; }

        [FindsBy(How = How.Id, Using = "jobTitle_jobSpec")]
        [CacheLookup]
        public IWebElement JobSpecBtn { get; set; }

        [FindsBy(How = How.Id, Using = "jobTitle_note")]
        [CacheLookup]
        public IWebElement Note { get; set; }

        //[FindsBy(How = How.Id, Using = "btnSave")]
        //[CacheLookup]
        //public IWebElement SaveBtn { get; set; }

        //[FindsBy(How = How.Id, Using = "btnCancel")]
        //[CacheLookup]
       // public IWebElement CancelBtn { get; set; }

        #endregion

        internal static void AddJobTitle(string jobTitle, string jobDescription = "", string note = "")
        {
            _logger.Info("Entering AddJobTitle().");

            Pages.JobTitles.AddBtn.Click();
            Pages.JobTitles.JobTitle.Clear();
            Pages.JobTitles.JobTitle.SendKeys(jobTitle + Keys.Tab);
            Pages.JobTitles.JobDescription.Clear();
            Pages.JobTitles.JobDescription.SendKeys(jobDescription + Keys.Tab);
            Pages.JobTitles.Note.Clear();
            Pages.JobTitles.Note.SendKeys(note + Keys.Tab);

            Pages.JobTitles.SaveBtn.Click();

            _logger.Info("Exiting AddJobTitle().");
        }

        internal static void EditJobTitle(string searchCriteria, string jobTitle, string jobDescription = "", string note = "")
        {
            _logger.Info("Entering EditJobTitle().");

            try
            {
                // Locate record to edit
                int jobTitleRow = Pages.JobTitles.SearchForRowContainingRecord(searchCriteria, "resultTable");

                //_driver.FindElement(By.XPath($"//tbody/tr[{jobTitleRow}]/td[1]")).Click();
                Pages.JobTitles._driver.FindElement(By.LinkText(searchCriteria)).Click();

                Pages.JobTitles.EditBtn.Click();

                Pages.JobTitles.JobTitle.Clear();
                Pages.JobTitles.JobTitle.SendKeys(jobTitle + Keys.Tab);
                Pages.JobTitles.JobDescription.Clear();
                Pages.JobTitles.JobDescription.SendKeys(jobDescription + Keys.Tab);
                Pages.JobTitles.Note.Clear();
                Pages.JobTitles.Note.SendKeys(note + Keys.Tab);

                Pages.JobTitles.SaveBtn.Click();

                _logger.Info("Exiting EditJobTitle().");
            }
            catch
            {
                throw new Exception($"The expected record: {searchCriteria} could not be found!");
            }           
        }

        internal static void DeleteJobTitle(string jobTitle)
        {
            _logger.Info("Entering DeleteJobTitle().");
            try
            {
                // Locate record to delete
                int jobTitleRow = Pages.JobTitles.SearchForRowContainingRecord(jobTitle, "resultTable");
                Pages.JobTitles._driver.FindElement(By.XPath($"//tbody/tr[{jobTitleRow}]/td")).Click();

                Pages.JobTitles.DeleteBtn.Click();

                Pages.Dialog.OkButton.Click();
            }
            catch
            {
                throw new Exception($"The expected Job Title: {jobTitle} could not be found!");
            }
            finally
            {
                _logger.Info("Exiting DeleteJobTitle().");
            }
        }

        internal static bool? JobTitleCorrectlyAdded(string jobTitle, string jobDescription = "")
        {
            _logger.Info("Entering JobTitleCorrectlyAdded().");
            //Build an array of data used to run extracted data against
            string[] jobTitleData = new string[] { "", jobTitle, jobDescription };

            try
            {
                _logger.Info("Getting index of row containing Job Titler.");

                int jobTitleRow = Pages.JobTitles.SearchForRowContainingRecord(jobTitle, "resultTable");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.JobTitles._driver.FindElements(By.XPath($"//tbody/tr[{jobTitleRow}]/td"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in TableData)
                {
                    if ((item.Text != "") || (item.Text != null))
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, jobTitleData);
            }
            catch
            {
                _logger.Info("The Job Title was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting JobTitleCorrectlyAdded().");
            }
        }

        internal static bool? JobTitleCorrectlyDeleted(string jobTitle)
        {
            _logger.Info("Entering JobTitleCorrectlyDeleted().");
            try
            {
                int jobTitleRow = Pages.JobTitles.SearchForRowContainingRecord(jobTitle, "resultTable");
                return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                _logger.Info("Exiting JobTitleCorrectlyDeleted().");
            }
        }


    }
}