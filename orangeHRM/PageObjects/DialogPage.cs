using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Dialog : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "dialogDeleteBtn")]
        [CacheLookup]
        public IWebElement OkButton { get; set; }

        [FindsBy(How = How.Id, Using = "dialogNo")]
        [CacheLookup]
        public IWebElement CancelButton { get; set; }

        [FindsBy(How = How.Id, Using = "dialogYes")]
        [CacheLookup]
        public IWebElement OkBtn { get; set; }
        #endregion
    }
}