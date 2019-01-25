using System;
using System.Threading;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class AddEmployee : OrangeHRM
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        //Employee details
        [FindsBy(How = How.Id, Using = "firstName")]
        [CacheLookup]
        public IWebElement FirstName { get; set; }
        //private static IWebElement FirstName => Driver.FindElement(By.Id("firstName"));

        [FindsBy(How = How.Id, Using = "middleName")]
        [CacheLookup]
        public IWebElement MiddleName { get; set; }
        //private static IWebElement MiddleName => Driver.FindElement(By.Id("middleName"));

        [FindsBy(How = How.Id, Using = "lastName")]
        [CacheLookup]
        public IWebElement LastName { get; set; }
        //private static IWebElement LastName => Driver.FindElement(By.Id("lastName"));

        [FindsBy(How = How.Id, Using = "chkLogin")]
        [CacheLookup]
        public IWebElement CreateLoginDetailsCheckbox { get; set; }
        //private static IWebElement CreateLoginDetailsCheckbox => Driver.FindElement(By.Id("chkLogin"));

        //Login details
        [FindsBy(How = How.Id, Using = "user_name")]
        [CacheLookup]
        public IWebElement UserName { get; set; }
        //private static IWebElement UserName => Driver.FindElement(By.Id("user_name"));

        [FindsBy(How = How.Id, Using = "user_password")]
        [CacheLookup]
        public IWebElement Password { get; set; }
        //private static IWebElement Password => Driver.FindElement(By.Id("user_password"));

        [FindsBy(How = How.Id, Using = "re_password")]
        [CacheLookup]
        public IWebElement ConfirmPassword { get; set; }
        //private static IWebElement ConfirmPassword => Driver.FindElement(By.Id("re_password"));

        [FindsBy(How = How.Id, Using = "status")]
        [CacheLookup]
        public IWebElement StatusDropDown { get; set; }
        //private static IWebElement StatusDropDown => Driver.FindElement(By.Id("status"));

        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        public IWebElement SaveButton { get; set; }
        //private static IWebElement _saveButton => Driver.FindElement(By.Id("btnSave"));
        #endregion

        internal void AddAnEmployee(string firstName, string middleName, string lastName, bool createLoginDetails, string userName, string password, string status)
        {
            _logger.Info($"AddEmployee called with: {firstName} {middleName} {lastName}, Username: {userName}, Password: {password}, Status: {status}");
            FirstName.SendKeys(firstName);
            MiddleName.SendKeys(middleName);
            LastName.SendKeys(lastName);
            // No login for Contractors
            if (createLoginDetails)
            {
                CreateLoginDetailsCheckbox.Click();
                UserName.SendKeys(userName);
                Password.SendKeys(password);
                ConfirmPassword.SendKeys(password);
                StatusDropDown.Click();
                StatusDropDown.FindElement(By.XPath(".//*[@value='" + status + "']")).Click();
            }
            
            SaveButton.Click();
            Thread.Sleep(2000);
 
        }
    }

}