using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace OrangeHRM.PageObjects
{
    public class TerminateEmploymentDialog : OrangeHRM
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "terminate_reason")]
        [CacheLookup]
        public IWebElement Reason { get; set; }
        //private static IWebElement Reason = Driver.FindElement(By.Id("terminate_reason"));

        [FindsBy(How = How.Id, Using = "terminate_date")]
        [CacheLookup]
        public IWebElement Date { get; set; }
        //private static IWebElement Date = Driver.FindElement(By.Id("terminate_date"));

        [FindsBy(How = How.Id, Using = "terminate_note")]
        [CacheLookup]
        public IWebElement Note { get; set; }
        //private static IWebElement Note = Driver.FindElement(By.Id("terminate_note"));

        [FindsBy(How = How.Id, Using = "dialogConfirm")]
        [CacheLookup]
        public IWebElement ConfirmBtn { get; set; }
        //private static IWebElement ConfirmBtn = Driver.FindElement(By.Id("dialogConfirm"));

        [FindsBy(How = How.Id, Using = "dialogCancel")]
        [CacheLookup]
        public IWebElement CancelBtn { get; set; }
        //private static IWebElement CancelBtn = Driver.FindElement(By.Id("dialogCancel"));
        #endregion

        internal void TerminateEmployment(string reason, string date, string note = null)
        {
            _logger.Info("Entering TerminateEmployment()");

            // Fill out dialog
            Reason.SendKeys(reason);
            Date.Clear();
            Date.SendKeys(date + Keys.Tab);
            Note.SendKeys(note);

            // Confirm the termination
            ConfirmBtn.Click();

            _logger.Info("Exiting TerminateEmployment()");
        }
    }
}