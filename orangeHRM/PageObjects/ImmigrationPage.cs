using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrangeHRM.PageObjects
{
    public class Immigration : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "immigration_number")]
        [CacheLookup]
        public IWebElement DocNum { get; set; }

        [FindsBy(How = How.Id, Using = "immigration_passport_issue_date")]
        [CacheLookup]
        public IWebElement IssDate { get; set; }

        [FindsBy(How = How.Id, Using = "immigration_passport_expire_date")]
        [CacheLookup]
        public IWebElement ExDate { get; set; }

        [FindsBy(How = How.Id, Using = "immigration_i9_status")]
        [CacheLookup]
        public IWebElement ElStatus { get; set; }

        [FindsBy(How = How.Id, Using = "immigration_country")]
        [CacheLookup]
        public IWebElement IssBy { get; set; }

        [FindsBy(How = How.Id, Using = "immigration_i9_review_date")]
        [CacheLookup]
        public IWebElement ElRevDate { get; set; }

        [FindsBy(How = How.Id, Using = "immigration_comments")]
        [CacheLookup]
        public IWebElement Comments { get; set; }
        #endregion

        internal void AddImmigrationRecord(string document, string docNumber, string issueDate = null, string expiryDate = null, string eligibilityStatus = null, 
            string issuedBy = null, string eligibilityReviewDate = null, string comments = null)
        {
            _logger.Info("Entering AddImmigrationRecord().");
            AddBtn.Click();
            // Decide which radio button to select
            if ((document == "Passport") || (document == "passport"))
                _driver.FindElement(By.Id("immigration_type_flag_1")).Click();
            else
                _driver.FindElement(By.Id("immigration_type_flag_2")).Click();
            //Enter remaining data 
            DocNum.SendKeys(docNumber);
            IssDate.Clear();
            IssDate.SendKeys(issueDate + Keys.Tab);
            ExDate.Clear();
            ExDate.SendKeys(expiryDate + Keys.Tab);
            ElStatus.SendKeys(eligibilityStatus);
            IssBy.SendKeys(issuedBy);
            ElRevDate.Clear();
            ElRevDate.SendKeys(eligibilityReviewDate + Keys.Tab);
            Comments.SendKeys(comments);
            //Click the Save button
            SaveBtn.Click();

            _logger.Info("Exiting AddImmigrationRecord().");
        }

        public static bool ImmigrationRecordCorrectlyAdded(string document, string docNumber, string issueDate = "", string expiryDate = "", string eligibilityStatus = "",
            string issuedBy = "", string eligibilityReviewDate = "", string comments = "")
        {
            _logger.Info("Entering ImmigrationRecordCorrectlyAdded().");

            //convert document to an id

            string documentID;

            if ((document == "Passport") || (document == "passport"))
                documentID = "1";
            else
                documentID = "2";

            //Build an array of data used to run extracted data against
            string[] ImmigrationData = new string[] {documentID, docNumber, issueDate, expiryDate, eligibilityStatus, CountryCountryCodeExpand(issuedBy), eligibilityReviewDate, comments };

            try
            {
                _logger.Info("Getting index of row containing Immigration Record.");
                //int docRow = SearchForDocument(docNumber);
                int docRow = Pages.OrangeHRM.SearchForRowContainingRecord(docNumber, "immidrationList");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.Immigration._driver.FindElements(By.XPath($"//tbody/tr[{docRow}]/input[@type='hidden']"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                //items.Add(Driver.FindElements(By.ClassName("dependentName"))[docRow].Text);
                foreach (IWebElement item in TableData)
                {
                    items.Add(item.GetAttribute("value"));
                }
                //compare the two data sets and return true if they are equal
                return Enumerable.SequenceEqual(items, ImmigrationData);
            }
            catch
            {
                _logger.Info("The Immigration Record was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting ImmigrationRecordCorrectlyAdded().");
            }
        }
    }
}