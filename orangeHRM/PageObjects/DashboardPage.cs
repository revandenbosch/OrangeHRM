using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Dashboard : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();


        // Page object definitions
        #region
        [FindsBy(How = How.XPath, Using = "//span[text()='Assign Leave']")]
        [CacheLookup]
        private IWebElement AssignLeave { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Leave List']")]
        [CacheLookup]
        private IWebElement LeaveList { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Timesheets']")]
        [CacheLookup]
        private IWebElement Timesheets { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='Apply Leave']")]
        [CacheLookup]
        private IWebElement ApplyLeave { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='My Leave']")]
        [CacheLookup]
        private IWebElement MyLeave { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[text()='My Timesheet']")]
        [CacheLookup]
        private IWebElement MyTimesheet { get; set; }

        #endregion

        public class AdminDashboard : Dashboard
        {

            internal static bool? HasCorrectPanels(string[] expectedData)
            {
                _logger.Info("Entering AdminDashboard.HasCorrectElements()");

                if (VerifyPanelList(expectedData) == true)
                {
                    _logger.Info("Exiting AdminDashboard.HasCorrectElements().");

                    return true;
                }
                else
                {
                    _logger.Info("Exiting AdminDashboard.HasCorrectElements().");

                    return false;
                }
            }

            internal static bool? HasCorrectQuickLaunchOptions(string[] expectedData)
            {
                _logger.Info("Entering HasCorrectQuickLaunchOptions()");

                if (VerifyQuickLaunchOptions(expectedData) == true)
                {
                    _logger.Info("Exiting HasCorrectQuickLaunchOptions().");

                    return true;
                }
                else
                {
                    _logger.Info("Exiting HasCorrectQuickLaunchOptions().");

                    return false;
                }
            }

            internal static bool? HasCorrectNumOfPieSegments()
            {
                _logger.Info("Entering HasCorrectNumOfPieSegments()");

                if (VerifyEEDistBySubunitPieChart() == true)
                {
                    _logger.Info("Exiting HasCorrectNumOfPieSegments().");

                    return true;
                }
                else
                {
                    _logger.Info("HasCorrectNumOfPieSegments().");
                    return false;
                }
            }

            internal static void SelectAssignLeave()
            {
                Pages.Dashboard.AssignLeave.Click();
            }

            internal static void SelectLeaveList()
            {
                Pages.Dashboard.LeaveList.Click();
            }

            internal static void SelectTimesheets()
            {
                Pages.Dashboard.Timesheets.Click();
            }
        }

        public class ESSDashboard : Dashboard
        {
            internal static bool? HasCorrectPanels(string[] expectedData)
            {
                _logger.Info("Entering ESSDashboard.HasCorrectElements()");

                if (VerifyPanelList(expectedData) == true)
                {
                    _logger.Info("Exiting ESSDashboard.HasCorrectElements().");

                    return true;
                }
                else
                {
                    _logger.Info("Exiting ESSDashboard.HasCorrectElements().");

                    return false;
                }
            }

            internal static bool? HasCorrectQuickLaunchOptions(string[] expectedData)
            {
                _logger.Info("Entering HasCorrectQuickLaunchOptions()");

                if (VerifyQuickLaunchOptions(expectedData) == true)
                {
                    _logger.Info("Exiting HasCorrectQuickLaunchOptions().");

                    return true;
                }
                else
                {
                    _logger.Info("Exiting HasCorrectQuickLaunchOptions().");

                    return false;
                }
            }

            internal static void SelectApplyLeave()
            {
                Pages.Dashboard.ApplyLeave.Click();
            }

            internal static void SelectMyLeave()
            {
                Pages.Dashboard.MyLeave.Click();
            }

            internal static void SelectMyTimesheet()
            {
                Pages.Dashboard.MyTimesheet.Click();
            }
        }

        private static bool VerifyPanelList(string[] expectedData)
        {
            _logger.Info("Entering VerifyPanelList()");

            try
            {
                IList<IWebElement> panelList = Pages.Dashboard._driver.FindElements(By.TagName("legend"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in panelList)
                {
                    if ((item.Text != "") || (item.Text != null))
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, expectedData);
            }
            catch
            {
                _logger.Info("Unable to locate expected elements!.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting VerifyPanelList().");
            }
        }

        private static bool VerifyQuickLaunchOptions(string[] expectedData)
        {
            _logger.Info("Entering VerifyQuickLaunchOptions()");

            try
            {
                IList<IWebElement> panelList = Pages.Dashboard._driver.FindElements(By.XPath("//*[@class='quickLaunge']/a"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in panelList)
                {
                    if ((item.Text != "") || (item.Text != null))
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, expectedData);
            }
            catch
            {
                _logger.Info("Unable to locate expected elements!.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting VerifyQuickLaunchOptions().");
            }
        }

        private static bool VerifyEEDistBySubunitPieChart()
        {
            _logger.Info("Entering VerifyEEDistBySubunitPieChart()");

            try
            {
                // Give the pie chart time to be calculated and displayed
                WebDriverWait wait = new WebDriverWait(Pages.Dashboard._driver, TimeSpan.FromSeconds(3));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("div_graph_display_emp_distribution")));

                // Count the number of pie segments
                int numPieSegments = Pages.Dashboard._driver.FindElements(By.XPath("//*[@class='pieLabel']")).Count();

                // Count the number of Legend keys
                int numLegendKeys = Pages.Dashboard._driver.FindElements(By.XPath("//*[@class='legendLabel']")).Count();

                if (numPieSegments == numLegendKeys)
                {
                    return true;
                }
                else
                {
                    return false;
                }    
            }
            catch
            {
                _logger.Info("Unable to locate expected elements!.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting VerifyEEDistBySubunitPieChart().");
            }
        }

        internal static bool? IsCorrectPage(string pageName)
        {
            try
            {
                string screenName = Pages.Dashboard._driver.FindElement(By.XPath("//div[@class='head']/h1")).Text;

                if (screenName == pageName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                try
                {
                    string altnName = Pages.Dashboard._driver.FindElement(By.XPath("//div[@class='top']/h3")).Text;

                    if (altnName == pageName)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
