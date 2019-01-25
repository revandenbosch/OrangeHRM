using System;
using System.Threading;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Time : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "menu_admin_ProjectInfo")]
        [CacheLookup]
        public IWebElement TimeProjectInfoMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "menu_admin_viewCustomers")]
        [CacheLookup]
        public IWebElement TimeProjectInfoCustomerMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "time_startingDays")]
        [CacheLookup]
        public IWebElement FirstDayOfWeek { get; set; }

        [FindsBy(How = How.Id, Using = "define_TimeSheet")]
        [CacheLookup]
        public IWebElement PageHeader { get; set; }

        [FindsBy(How = How.Id, Using = "startDates")]
        [CacheLookup]
        public IWebElement TimesheetForWeek { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddTimesheet")]
        [CacheLookup]
        public IWebElement AddTimesheet { get; set; }

        [FindsBy(How = How.Id, Using = "btnSubmit")]
        [CacheLookup]
        public IWebElement SubmitBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnAddRow")]
        [CacheLookup]
        public IWebElement AddRowBtn { get; set; }

        [FindsBy(How = How.Id, Using = "submitRemoveRows")]
        [CacheLookup]
        public IWebElement RemoveRowsBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnReset")]
        [CacheLookup]
        public IWebElement ResetBtn { get; set; }

        [FindsBy(How = How.Id, Using = "submitSave")]
        [CacheLookup]
        public new IWebElement SaveBtn { get; set; }

        #endregion

        public class DefineTimesheetPeriod
        {
            internal static bool? IsDefineTimesheetPeriodDisplayed()
            {
                try
                {
                    bool status = Pages.Time.PageHeader.Displayed;
                    return status;
                }
                catch
                {
                    return false;
                }
            }
        }

        public static void SetFirstDayOfWeek(string firstDayOfWeek)
        {
            Pages.Time.FirstDayOfWeek.SendKeys(firstDayOfWeek);
            Pages.Time.SaveBtn.Click();
        }

        public class EditTimesheet
        {
            public static void AddRow(string projectName, string activityName, double day1, double day2, double day3, double day4, double day5, double day6, double day7)
            {
                _logger.Info("Entering AddRow().");
                try
                {
                    
                    if (Pages.Time._driver.FindElements(By.XPath("//table/tbody/tr")).Count == 1)
                        {
                        int rowIndex = 0;

                        WebDriverWait wait = new WebDriverWait(Pages.Time._driver, TimeSpan.FromSeconds(15));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("btnEdit"))).Click();
                        //Pages.Time.EditBtn.Click();
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectName")).Clear();
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectName")).SendKeys(projectName + Keys.Enter);
                        Thread.Sleep(5000);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectName")).SendKeys(Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectActivityName")).SendKeys(activityName + Keys.Return + Keys.Tab);
                        Thread.Sleep(5000);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectActivityName")).SendKeys(Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_0")).SendKeys(day1.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_1")).SendKeys(day2.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_2")).SendKeys(day3.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_3")).SendKeys(day4.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_4")).SendKeys(day5.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_5")).SendKeys(day6.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_6")).SendKeys(day7.ToString() + Keys.Tab);

                        Pages.Time.SaveBtn.Click();

                    }
                    else
                    {
                        int rowIndex = Pages.Time._driver.FindElements(By.XPath("//table/tbody/tr")).Count - 1;

                        WebDriverWait wait = new WebDriverWait(Pages.Time._driver, TimeSpan.FromSeconds(15));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("btnEdit"))).Click();
                        //Pages.Time.EditBtn.Click();

                        WebDriverWait wait2 = new WebDriverWait(Pages.Time._driver, TimeSpan.FromSeconds(15));
                        wait2.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("btnAddRow"))).Click();

                        //Pages.Time.AddRowBtn.Click();
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectName")).Clear();
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectName")).SendKeys(projectName + Keys.Return + Keys.Tab);
                        Thread.Sleep(10);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_projectActivityName")).SendKeys(activityName + Keys.Return + Keys.Tab);

                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_0")).SendKeys(day1.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_1")).SendKeys(day2.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_2")).SendKeys(day3.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_3")).SendKeys(day4.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_4")).SendKeys(day5.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_5")).SendKeys(day6.ToString() + Keys.Tab);
                        Pages.Time._driver.FindElement(By.Id("initialRows_" + rowIndex + "_6")).SendKeys(day7.ToString() + Keys.Tab);

                        Pages.Time.SaveBtn.Click();
                    }

                }
                catch( Exception ex)
                {
                    throw new Exception($"A problem was detected trying to add a row to a timesheet: {ex}.");
                }
                finally
                {
                    _logger.Info("Exiting AddRow().");
                }
            }

            internal static void SubmitTimesheet()
            {
                Pages.Time.SubmitBtn.Click();
            }
        }
       
    }  
}