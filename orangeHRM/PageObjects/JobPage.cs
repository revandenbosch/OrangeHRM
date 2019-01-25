using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRM.PageObjects;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrangeHRM.PageObjects
{
    public class Job : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        public IWebElement EditBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        public IWebElement SaveBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnTerminateEmployement")]
        [CacheLookup]
        public IWebElement TerminateEmpBtn { get; set; }
 
        [FindsBy(How = How.Id, Using = "job_job_title")]
        [CacheLookup]
        public IWebElement JobTitle { get; set; }
 
        [FindsBy(How = How.Id, Using = "job_emp_status")]
        [CacheLookup]
        public IWebElement EmpStatus { get; set; }

        [FindsBy(How = How.Id, Using = "job_eeo_category")]
        [CacheLookup]
        public IWebElement JobCat { get; set; }

        [FindsBy(How = How.Id, Using = "job_joined_date")]
        [CacheLookup]
        public IWebElement StartDate { get; set; }

        [FindsBy(How = How.Id, Using = "job_sub_unit")]
        [CacheLookup]
        public IWebElement SubUnit { get; set; }

        [FindsBy(How = How.Id, Using = "job_location")]
        [CacheLookup]
        public IWebElement Loc { get; set; }

        [FindsBy(How = How.Id, Using = "job_contract_start_date")]
        [CacheLookup]
        public IWebElement ECStartDate { get; set; }

        [FindsBy(How = How.Id, Using = "job_contract_end_date")]
        [CacheLookup]
        public IWebElement ECEndDate { get; set; }
        #endregion

        public static void AddJob(string jobTitle = null, string empStatus = null, string jobCat = null, string joinDate = null, string subUnit = null, 
            string location = null, string ecStartDate = null, string ecEndDate = null)
        {
            _logger.Info("Entering AddJob().");
            
            Pages.Job.EditBtn.Click();
            Pages.Job.JobTitle.SendKeys(jobTitle);
            //JobSpec.SendKeys(jobSpec);
            Pages.Job.EmpStatus.SendKeys(empStatus);
            Pages.Job.JobCat.SendKeys(jobCat);
            Pages.Job.StartDate.Clear();
            Pages.Job.StartDate.SendKeys(joinDate + Keys.Tab);
            Pages.Job.SubUnit.SendKeys(subUnit);
            Pages.Job.Loc.SendKeys(location);
            Pages.Job.ECStartDate.Clear();
            Pages.Job.ECStartDate.SendKeys(ecStartDate + Keys.Tab);
            Pages.Job.ECEndDate.Clear();
            Pages.Job.ECEndDate.SendKeys(ecEndDate + Keys.Tab);

            // Click Save button.
            Pages.Job.SaveBtn.Click();
 
            _logger.Info("Exiting AddJob().");
        }

        public static bool JobCorrectlyAdded(string jobTitle = "", string empStatus = "", string jobCat = "", string joinDate = "", string subUnit = "",
            string location = "", string ecStartDate = "", string ecEndDate = "")
        {
            _logger.Info("Entering JobCorrectlyAdded().");
           

            try
            {
                //Problem with page returning "yyy-mm-dd" so adding work around
                if (joinDate == "")
                    joinDate = "yyy-mm-dd";
                if (ecStartDate == "")
                    ecStartDate = "yyyy-mm-dd";
                if (ecEndDate == "")
                    ecEndDate = "yyyy-mm-dd";
                //Build an array of data used to run extracted data against
                string[] JobDetailsData = new string[] { joinDate, ecStartDate, ecEndDate, jobTitle, empStatus, jobCat, subUnit, location, "Other" };

                _logger.Info("Getting the data from the page");
                //Get the data from the page
                IList<IWebElement> PageData1 = Pages.Job._driver.FindElements(By.XPath("//*/input[@type='text' and @name != 'terminate[date]']"));
                //Get the drop down selected values
                IList<IWebElement> PageData2 = Pages.Job._driver.FindElements(By.XPath("//option[@selected='selected']"));

                List<string> items = new List<string>();
                foreach (IWebElement item in PageData1)
                {
                    items.Add(item.GetAttribute("value"));
                }
                foreach (IWebElement item in PageData2)
                {
                    items.Add(item.GetAttribute("text"));
                }
                //compare the two data sets and return true if they are equal
                return Enumerable.SequenceEqual(items, JobDetailsData);
            }

            catch
            {
                _logger.Info("The Job was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting JobCorrectlyAdded().");
            } 
        }

        internal static void ActivateEmployee()
        {
            _logger.Info("Entering ActivateEmployee().");

            IWebElement ActivateEmpBtn = Pages.Job._driver.FindElement(By.Id("btnTerminateEmployement"));

            ActivateEmpBtn.Click();

            _logger.Info("Exiting ActivateEmployee().");
        }

        internal static void TerminateEmployee(string reason, string date, string note = null)
        {
            _logger.Info("Entering TerminateEmployee().");

            IWebElement TermEmpBtn = Pages.Job._driver.FindElement(By.Id("btnTerminateEmployement"));

            // Click Terminate Employee button
            TermEmpBtn.Click();
            Pages.TerminateEmployment.TerminateEmployment(reason, date, note);

            _logger.Info("Exiting TerminateEmployee().");
        }

        internal static bool EmployeeTerminated(string date)
        {
            _logger.Info("Entering EmployeeTerminated()");

            WebDriverWait wait = new WebDriverWait(Pages.Job._driver, TimeSpan.FromSeconds(10));

            _logger.Info($"Locating Terminated on: {date}.");
            _logger.Info("Exiting EmployeeTerminated()");
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath($"//a[contains(text(),'Terminated on : {date}')]"))).Displayed;
        }

        internal static bool? IsActiveEmployee(string eeName)
        {
            _logger.Info("Entering IsActiveEmployee().");

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);

            Table w3cTable = new Table(Pages.Job._driver.FindElement(By.Id("resultTable")));

            _logger.Info("Exiting IsActiveEmployee().");
            return !w3cTable.IsEmpty(w3cTable);
        }

    }
}