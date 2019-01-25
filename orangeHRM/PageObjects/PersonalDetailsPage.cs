using System;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class PersonalDetails : Employee
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "personal_txtEmpFirstName")]
        [CacheLookup]
        public IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "personal_txtEmpMiddleName")]
        [CacheLookup]
        public IWebElement MiddleName { get; set; }

        [FindsBy(How = How.Id, Using = "personal_txtEmpLastName")]
        [CacheLookup]
        public IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "personal_txtEmployeeId")]
        [CacheLookup]
        public IWebElement EmployeeId { get; set; }

        [FindsBy(How = How.Id, Using = "personal_txtOtherID")]
        [CacheLookup]
        public IWebElement OtherId { get; set; }

        [FindsBy(How = How.Id, Using = "personal_txtLicenNo")]
        [CacheLookup]
        public IWebElement DriversLicense { get; set; }

        [FindsBy(How = How.Id, Using = "personal_txtLicExpDate")]
        [CacheLookup]
        public IWebElement LicenseExpDate { get; set; }

        [FindsBy(How = How.Id, Using = "personal_cmbMarital")]
        [CacheLookup]
        public IWebElement MaritalStatus { get; set; }

        [FindsBy(How = How.Id, Using = "personal_cmbNation")]
        [CacheLookup]
        public IWebElement Nationality { get; set; }

        [FindsBy(How = How.Id, Using = "personal_DOB")]
        [CacheLookup]
        public IWebElement DOB { get; set; }
        #endregion

        internal void EditFirstName(string firstName)
        {
            _logger.Info("Entering EditFirstName()");
            FirstName.Clear();
            FirstName.SendKeys(firstName);
            _logger.Info("Exiting EditFirstName()");
        }

        internal void EditMiddleName(string middleName)
        {
            _logger.Info("Entering EditMiddleName()");
            MiddleName.Clear();
            MiddleName.SendKeys(middleName);
            _logger.Info("Exiting EditMiddleName()");
        }

        internal void EditLastName(string lastName)
        {
            _logger.Info("Entering EditLastName()");
            LastName.Clear();
            LastName.SendKeys(lastName);
            _logger.Info("Exiting EditLastName()");
        }

        internal void EditEmployeeId(string employeeId)
        {
            _logger.Info("Entering EditEmployeeId()");
            EmployeeId.Clear();
            EmployeeId.SendKeys(employeeId);
            _logger.Info("Exiting EditEmployeeId()");
        }

        internal void EditOtherId(string otherId)
        {
            _logger.Info("Entering EditOtherId()");
            OtherId.Clear();
            OtherId.SendKeys(otherId);
            _logger.Info("Exiting EditOtherId()");
        }

        internal void EditDriversLicense(string driversLicense)
        {
            _logger.Info("Entering EditDriversLicense()");
            DriversLicense.Clear();
            DriversLicense.SendKeys(driversLicense);
            _logger.Info("Exiting EditDriversLicense()");
        }

        internal void EditLicenseExpDate(string licenseExpDate)
        {
            _logger.Info("Entering EditLicenseExpDate()");
            LicenseExpDate.Clear();
            LicenseExpDate.SendKeys(licenseExpDate);
            _logger.Info("Exiting EditLicenseExpDate()");
        }

        internal void EditGender(string gender)
        {
            _logger.Info("Entering EditGender()");
            if ((gender == "Male") || (gender == "male") || (gender == "M") || (gender == "m"))
            {
                _driver.FindElement(By.Id("personal_optGender_1")).Click();
            }
            else
            {
                _driver.FindElement(By.Id("personal_optGender_2")).Click();
            }
            _logger.Info("Exiting EditGender()");
        }

        internal void EditMaritalStatus(string maritalStatus)
        {
            _logger.Info("Entering EditMaritalStatus()");
            MaritalStatus.SendKeys(maritalStatus);
            _logger.Info("Exiting EditMaritalStatus()");
        }

        internal void EditNationality(string nationality)
        {
            _logger.Info("Entering EditNationality()");
            Nationality.SendKeys(nationality);
            _logger.Info("Exiting EditNationality()");
        }

        internal void EditDOB(string dob)
        {
            _logger.Info("Entering EditDOB()");
            DOB.Clear();
            DOB.SendKeys(dob);
            _logger.Info("Exiting EditDOB()");
        }
    }
}