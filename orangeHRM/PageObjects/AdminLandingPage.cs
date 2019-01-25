using System;
using System.Collections.Generic;
using System.Linq;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;

namespace OrangeHRM.PageObjects
{
    public class AdminLanding : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static bool? IsCorrectMenu(string[] expectedData)
        {
            _logger.Info("IsCorrectMenu called.)");

            List<string> items = new List<string>();
            foreach (IWebElement item in Pages.Menu.MenuItems)
            {
                items.Add(item.Text);
            }
            _logger.Info($"Comparing Expected: {expectedData} to Actual: {items}.");

            return Enumerable.SequenceEqual(items, expectedData);
        }

        /*
        internal static bool? IsEmpty(Table w3cTable)
        {
            _logger.Info("Entering isEmpty()");

            int rowCount = w3cTable.RowCount();

            if (rowCount == 0)
            {
                _logger.Info("Exiting isEmpty()");
                return true;
            }
            _logger.Info("Exiting isEmpty()");

            // At least 1 record exists from search
            return false;
        }
        */
    }
}