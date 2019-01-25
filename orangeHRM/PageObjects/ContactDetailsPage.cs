using System;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class ContactDetails : EmployeeList
    {

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private IWebDriver _driver = BrowserFactory.Driver;

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "contact_street1")]
        [CacheLookup]
        public IWebElement Contact_street1 { get; set; }

        [FindsBy(How = How.Id, Using = "contact_street2")]
        [CacheLookup]
        public IWebElement Contact_street2 { get; set; }

        [FindsBy(How = How.Id, Using = "contact_city")]
        [CacheLookup]
        public IWebElement Contact_city { get; set; }

        [FindsBy(How = How.Id, Using = "contact_state")]
        [CacheLookup]
        public IWebElement Contact_state { get; set; }

        [FindsBy(How = How.Id, Using = "contact_emp_zipcode")]
        [CacheLookup]
        public IWebElement Contact_zip { get; set; }

        [FindsBy(How = How.Id, Using = "contact_country")]
        [CacheLookup]
        public IWebElement Contact_country { get; set; }

        [FindsBy(How = How.Id, Using = "contact_emp_hm_telephone")]
        [CacheLookup]
        public IWebElement Contact_home_phone { get; set; }

        [FindsBy(How = How.Id, Using = "contact_emp_mobile")]
        [CacheLookup]
        public IWebElement Contact_mobile { get; set; }

        [FindsBy(How = How.Id, Using = "contact_emp_work_telephone")]
        [CacheLookup]
        public IWebElement Contact_work_phone { get; set; }

        [FindsBy(How = How.Id, Using = "contact_emp_work_email")]
        [CacheLookup]
        public IWebElement Contact_work_email { get; set; }

        [FindsBy(How = How.Id, Using = "contact_emp_oth_email")]
        [CacheLookup]
        public IWebElement Contact_other_email { get; set; }
        #endregion

        public void EditAddr1(string addr1)
        {
            _logger.Info($"EditAddr1 called with: {addr1}.");
            Contact_street1.Clear();
            Contact_street1.SendKeys(addr1);
            //_driver.FindElement(By.Id("contact_street1")).Clear();
            //_driver.FindElement(By.Id("contact_street1")).SendKeys(addr1);
        }

        public void EditAddr2(string addr2)
        {
            _logger.Info($"EditAddr2 called with: {addr2}.");
            Contact_street2.Clear();
            Contact_street2.SendKeys(addr2);
            //_driver.FindElement(By.Id("contact_street2")).Clear();
            //_driver.FindElement(By.Id("contact_street2")).SendKeys(addr2);
        }

        public void EditCity(string city)
        {
            _logger.Info($"Editcity called with: {city}.");
            Contact_city.Clear();
            Contact_city.SendKeys(city);
            //_driver.FindElement(By.Id("contact_city")).Clear();
            //_driver.FindElement(By.Id("contact_city")).SendKeys(city);
        }

        public void EditState(string state)
        {
            _logger.Info($"EditState called with: {state}.");
            //Driver.FindElement(By.Id("contact_state")).Clear();
            //_driver.FindElement(By.Id("contact_state")).SendKeys(state);
            Contact_state.SendKeys(state);
        }

        public void EditZip(string zip)
        {
            _logger.Info($"EditZip called with: {zip}.");
            // _driver.FindElement(By.Id("contact_emp_zipcode")).Clear();
            // _driver.FindElement(By.Id("contact_emp_zipcode")).SendKeys(zip);
            Contact_zip.Clear();
            Contact_zip.SendKeys(zip);

        }

        public void EditCountry(string country)
        {
            _logger.Info($"EditCountry called with: {country}.");
            Contact_country.SendKeys(country);
            //_driver.FindElement(By.Id("contact_country")).SendKeys(country);
        }

        public void EditHomePhone(string homePhone)
        {
            _logger.Info($"EditHomePhone called with: {homePhone}.");
            Contact_home_phone.Clear();
            Contact_home_phone.SendKeys(homePhone);
            //_driver.FindElement(By.Id("contact_emp_hm_telephone")).Clear();
            //_driver.FindElement(By.Id("contact_emp_hm_telephone")).SendKeys(homePhone);
        }

        public void EditMobilePhone(string mobilePhone)
        {
            _logger.Info($"EditMobilePhone called with: {mobilePhone}.");
            Contact_mobile.Clear();
            Contact_mobile.SendKeys(mobilePhone);
            //_driver.FindElement(By.Id("contact_emp_mobile")).Clear();
            //_driver.FindElement(By.Id("contact_emp_mobile")).SendKeys(mobilePhone);
        }

        public void EditWorkPhone(string workPhone)
        {
            _logger.Info($"EditWorkPhone called with: {workPhone}.");
            Contact_work_phone.Clear();
            Contact_work_phone.SendKeys(workPhone);
            //_driver.FindElement(By.Id("contact_emp_work_telephone")).Clear();
            //_driver.FindElement(By.Id("contact_emp_work_telephone")).SendKeys(workPhone);
        }

        public void EditWorkEmail(string workEmail)
        {
            _logger.Info($"EditWorkEmail called with: {workEmail}.");
            Contact_work_email.Clear();
            Contact_work_email.SendKeys(workEmail);
            // _driver.FindElement(By.Id("contact_emp_work_email")).Clear();
            //_driver.FindElement(By.Id("contact_emp_work_email")).SendKeys(workEmail);
        }

        public void EditOtherEmail(string otherEmail)
        {
            _logger.Info($"EditOtherEmail called with: {otherEmail}.");
            Contact_other_email.Clear();
            Contact_other_email.SendKeys(otherEmail);

            //_driver.FindElement(By.Id("contact_emp_oth_email")).Clear();
            //_driver.FindElement(By.Id("contact_emp_oth_email")).SendKeys(otherEmail);
        }
    }
}