using NLog;
using OpenQA.Selenium;
using OrangeHRM.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace OrangeHRM.PageObjects
{
    public class EssLanding : OrangeHRM
    {       
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
    }
}