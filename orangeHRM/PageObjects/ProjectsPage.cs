using System;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Projects : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "addProject_customerName")]
        [CacheLookup]
        public IWebElement CustomerName { get; set; }

        [FindsBy(How = How.Id, Using = "addProject_projectName")]
        [CacheLookup]
        public IWebElement ProjectName { get; set; }

        [FindsBy(How = How.Id, Using = "addProject_projectAdmin_1")]
        [CacheLookup]
        public IWebElement ProjectAdmin { get; set; }

        [FindsBy(How = How.Id, Using = "addProject_description")]
        [CacheLookup]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.Id, Using = "addCustomerLink")]
        [CacheLookup]
        public IWebElement AddCustomer { get; set; }

        [FindsBy(How = How.Id, Using = "addButton")]
        [CacheLookup]
        public IWebElement AddAnother { get; set; }

        [FindsBy(How = How.Id, Using = "addProjectActivity_activityName")]
        [CacheLookup]
        public IWebElement ActivityName { get; set; }

        [FindsBy(How = How.Id, Using = "btnActSave")]
        [CacheLookup]
        public IWebElement SaveActivityBtn { get; set; }

        #endregion

        internal static void AddNewProject(string customerName, string projectName, string projectAdmin, string projectDescription ="")
        {
            _logger.Info("Entering AddNewProject().");

            try
            {
                Pages.Projects.AddBtn.Click();

                Pages.Projects.CustomerName.SendKeys(customerName + Keys.Down + Keys.Tab);
                Pages.Projects.ProjectName.SendKeys(projectName + Keys.Tab);
                Pages.Projects.ProjectAdmin.SendKeys(projectAdmin + Keys.Tab);
                Pages.Projects.Description.SendKeys(projectDescription);

                Pages.Projects.SaveBtn.Click();

            }
            catch (Exception ex)
            {
                throw new Exception($"A problem was encountered trying to create the requested Project: {ex}.");
            }
            finally
            {
                _logger.Info("Exiting AddNewProject().");
            }
        }

        internal static void AddProjectActivity(string activityName)
        {
            _logger.Info("Entering AddProjectActivity().");

            try
            {
                Pages.Projects.AddBtn.Click();

                Pages.Projects.ActivityName.SendKeys(activityName);

                Pages.Projects.SaveActivityBtn.Click();
            }
            catch
            {

            }
            finally
            {
                _logger.Info("Exiting AddProjectActivity().");
            }
        }
    }
}