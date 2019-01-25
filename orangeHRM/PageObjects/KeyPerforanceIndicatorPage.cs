using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class KeyPerformanceIndicator : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "defineKpi360_jobTitleCode")]
        [CacheLookup]
        public IWebElement JobTitle { get; set; }

        [FindsBy(How = How.Id, Using = "defineKpi360_keyPerformanceIndicators")]
        [CacheLookup]
        public IWebElement KPI { get; set; }

        [FindsBy(How = How.Id, Using = "defineKpi360_minRating")]
        [CacheLookup]
        public IWebElement MinRating { get; set; }

        [FindsBy(How = How.Id, Using = "defineKpi360_maxRating")]
        [CacheLookup]
        public IWebElement MaxRating { get; set; }

        [FindsBy(How = How.Id, Using = "defineKpi360_makeDefault")]
        [CacheLookup]
        public IWebElement MakeDefaultScale { get; set; }

        [FindsBy(How = How.Id, Using = "saveBtn")]
        [CacheLookup]
        public IWebElement SaveBtn { get; set; }

        #endregion


        internal static void AddKPI(string jobTitle, string kPI, int minRating, int maxRating, bool makeDefaultScale)
        {
            _logger.Info("Entering AddKPI().");

            Pages.KeyPerformanceIndicator.AddBtn.Click();
            Pages.KeyPerformanceIndicator.JobTitle.SendKeys(jobTitle + Keys.Tab);
            Pages.KeyPerformanceIndicator.KPI.SendKeys(kPI + Keys.Tab);
            Pages.KeyPerformanceIndicator.MinRating.SendKeys(minRating + Keys.Tab);
            Pages.KeyPerformanceIndicator.MaxRating.SendKeys(maxRating + Keys.Tab);
            if (makeDefaultScale == true)
                Pages.KeyPerformanceIndicator.MakeDefaultScale.Click();

            Pages.KeyPerformanceIndicator.SaveBtn.Click();

            _logger.Info("Entering AddKPI().");
        }

        internal static bool KPICorrectlyAdded(string jobTitle, string kPI, int minRating, int maxRating, bool makeDefaultScale)
        {
            _logger.Info("Entering KPICorrectlyAdded().");

            string defaultScale = "";

            // Convert bool to Yes/No
            if (makeDefaultScale == true)
                defaultScale = "Yes";

            //Build an array of data used to run extracted data against
            string[] kpiData = new string[] { "", kPI, jobTitle, minRating.ToString(), maxRating.ToString(), defaultScale };

            try
            {
                _logger.Info("Getting index of row containing pay grade.");

                int kpiRow = Pages.OrangeHRM.SearchForRowContainingRecord(kPI, "resultTable");
                
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.KeyPerformanceIndicator._driver.FindElements(By.XPath($"//tbody/tr[{kpiRow}]/td"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in TableData)
                {
                    if ((item.Text != "") || (item.Text != null))
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, kpiData);
            }
            catch
            {
                _logger.Info("The KPI was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Entering KPICorrectlyAdded().");
            }

            
        }


    }
}