using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Employee : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        private IWebElement EditBtn { get; set; }
        #endregion

        public static void EditPersonalDetails(string eeID, string firstName = null, string middleName = null, string lastName = null, string employeeId = null, string otherId = null, string driversLicense = null,
            string licenseExpDate = null, string gender = null, string maritalStatus = null, string nationality = null, string dob = null)
        {
            _logger.Info("Entering EditPersonalDetails().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement PersonalDetailsMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewPersonalDetails/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                PersonalDetailsMenu.Click(); // Select the Personal Details menu item

                Pages.Employee.EditBtn.Click(); // Enable the creen for editing
                _logger.Info("Enabling editing.");
                if (firstName != null)
                    Pages.PersonalDetails.EditFirstName(firstName);
                if (middleName != null)
                    Pages.PersonalDetails.EditMiddleName(middleName);
                if (lastName != null)
                    Pages.PersonalDetails.EditLastName(lastName);
                if (employeeId != null)
                    Pages.PersonalDetails.EditEmployeeId(employeeId);
                if (otherId != null)
                    Pages.PersonalDetails.EditOtherId(otherId);
                if (driversLicense != null)
                    Pages.PersonalDetails.EditDriversLicense(driversLicense);
                if (licenseExpDate != null)
                    Pages.PersonalDetails.EditLicenseExpDate(licenseExpDate);
                if (gender != null)
                    Pages.PersonalDetails.EditGender(gender);
                if (maritalStatus != null)
                    Pages.PersonalDetails.EditMaritalStatus(maritalStatus);
                if (nationality != null)
                    Pages.PersonalDetails.EditNationality(nationality);
                if (dob != null)
                    Pages.PersonalDetails.EditDOB(dob);
                _logger.Info("Saving the Employee data.");
                Pages.Employee.EditBtn.Click(); // save the record
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting EditPersonalDetails().");
            }
        }

        public static void AddSalary(string eeID, string payGrade, string salaryComponent, string currency, string amount, 
            bool directDeposit, string accountNumber, string accountType, string pleaseSpecify, string routingNumber, decimal amountDeposit, string payFrequency, string comments)
        {
            _logger.Info("Entering AddSalary().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                //IWebElement SalaryMenu = Driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewSalaryList/empNumber/" + eeID + "']"));
               // _logger.Info($"Employee with ID: {eeID} found.");

                WebDriverWait wait = new WebDriverWait(Pages.Employee._driver, TimeSpan.FromSeconds(10));
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/index.php/pim/viewSalaryList/empNumber/" + eeID + "']")));
                element.Click();
                //SalaryMenu.Click();
                AssignedSalaryComponents.AddSalary(payGrade, salaryComponent, payFrequency, currency, amount, comments, 
                    directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit);
            }
            catch (Exception ex)
            {
                _logger.Info("Unable to add Salary Component..");
                throw new Exception($"Unable to add Salary Component for Employee with ID: {eeID}.", ex);
            }
            finally
            {
                _logger.Info("Exitinging AddSalary().");
            }
        }

        public static void AddJob(string eeID, string jobTitle = null, string empStatus = null, string jobCat = null, string joinDate = null, string subUnit = null,
            string location = null, string ecStartDate = null, string ecEndDate = null)
        {
            _logger.Info("Entering AddJob().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement JobMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewJobDetails/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                JobMenu.Click();
                Job.AddJob(jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate);
            }
            catch(Exception ex)
            {
                _logger.Info("Unable to add Job..");
                throw new Exception($"Unable to add Job for Employee with ID: {eeID}.", ex);
            }
            finally
            {
                _logger.Info("Exiting AddJob().");
            }
        }

        internal static void TerminateEmployee(string eeID, string reason, string date, string note = null)
        {
            _logger.Info("Entering TerminateEmployee().");

            _logger.Info($"Searching for Employee with ID: {eeID}.");
            IWebElement JobMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewJobDetails/empNumber/" + eeID + "']"));
            _logger.Info($"Employee with ID: {eeID} found.");
            JobMenu.Click();

            Job.TerminateEmployee(reason, date, note);

            _logger.Info("Exiting TerminateEmployee().");
        }

        internal static void ActivateEmployee(string eeID)
        {
            _logger.Info("Entering ActivateEmployee().");

            _logger.Info($"Searching for Employee with ID: {eeID}.");
            IWebElement JobMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewJobDetails/empNumber/" + eeID + "']"));
            _logger.Info($"Employee with ID: {eeID} found.");

            JobMenu.Click();

            Job.ActivateEmployee();

            _logger.Info("Exiting ActivateEmployee().");
        }

        internal static bool ContactCorrectlyAdded(string addr1, string addr2, string city, string state, string zip, string country, string homePhone, string mobilePhone, string workPhone, string workEmail, string otherEmail)
        {
            _logger.Info("Entering ContactCorrectlyAdded().");
            //Build an array of data used to run extracted data against, note the 1 is there to account for column 1 which is a checkbox
            string[] ContactDetailsData = new string[] { addr1, addr2, city, OrangeHRM.AbbreviationStateExpand(state), zip,  homePhone, mobilePhone, workPhone, workEmail, otherEmail, country };
            
            try
            {
                _logger.Info("Getting the data from the page");
                //Get the data from the page
                IList<IWebElement> PageData = Pages.Employee._driver.FindElements(By.XPath("//*/input[@type='text']"));
                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in PageData)
                {
                      items.Add(item.GetAttribute("value"));
                }
                // Get the value of the country drop-down and add to items
                items.Add(Pages.Employee._driver.FindElements(By.XPath("//option[@selected='selected']"))[1].GetAttribute("text"));
                //compare the two data sets and return true if they are equal
                _logger.Info($"Comparing Expected: {ContactDetailsData} to Actual: {items}.");
                return Enumerable.SequenceEqual(items, ContactDetailsData);
            }

            catch
            {
                _logger.Info("The Contact was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting ContactCorrectlyAdded().");
            }
        }

        public static void EditContactDetails(string eeID, string addr1 = null, string addr2 = null, string city = null, string state = null, string zip = null, string country = null,
            string homePhone = null, string mobilePhone = null, string workPhone = null, string workEmail = null, string otherEmail = null)
        {
            _logger.Info("Entering EditContactDetails().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement ContactDetailsMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/contactDetails/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                ContactDetailsMenu.Click(); // Select the Contact Details menu item
                _logger.Info("Enabling editing.");
                Pages.Employee.EditBtn.Click(); // Enable the creen for editing

                if (addr1 != null)
                    Pages.ContactDetails.EditAddr1(addr1);
                if (addr2 != null)
                    Pages.ContactDetails.EditAddr2(addr2);
                if (city != null)
                    Pages.ContactDetails.EditCity(city);
                if (country != null)
                    Pages.ContactDetails.EditCountry(country);
                if (state != null)
                    Pages.ContactDetails.EditState(state);
                if (zip != null)
                    Pages.ContactDetails.EditZip(zip);
                if (homePhone != null)
                    Pages.ContactDetails.EditHomePhone(homePhone);
                if (mobilePhone != null)
                    Pages.ContactDetails.EditMobilePhone(mobilePhone);
                if (workPhone != null)
                    Pages.ContactDetails.EditWorkPhone(workPhone);
                if (workEmail != null)
                    Pages.ContactDetails.EditWorkEmail(workEmail);
                if (otherEmail != null)
                    Pages.ContactDetails.EditOtherEmail(otherEmail);
                _logger.Info("Saving the Employee Contact data.");
                Pages.Employee.EditBtn.Click(); // save the record
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting EditContactDetails().");
            }
        }

        public static void AddEmergencyContact(string eeID, string name, string relationship, string homePhone = null, string mobilePhone = null, string workPhone = null)
        {
            _logger.Info("Entering AddEmergencyContact().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement EmergencyContactsMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewEmergencyContacts/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                EmergencyContactsMenu.Click();
                Pages.AssignEmergencyContacts.AddEmergencyContact(name, relationship, homePhone, mobilePhone, workPhone);
            }
            catch
            {
                _logger.Info("Unable to add Emergency Contact..");
                throw new Exception($"Unable to add Emergency Contact for Employee with ID: {eeID}.");
            }
            finally
            {
                _logger.Info("Exiting AddEmergencyContact().");
            }
        }

        public static void AddDependent(string eeID, string name, string relationship, string other = null, string dob = null)
        {
            _logger.Info("Entering AddDependent().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement DependentsMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewDependents/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                DependentsMenu.Click();
                Pages.AssignDependent.AddDependent(name, relationship, other, dob);
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting AddDependent().");
            }
        }

        public static void AddImmigration(string eeID, string document, string docNumber, string issueDate = null, string expiryDate = null, string eligibilityStatus = null, 
            string issuedBy = null, string eligibilityReviewDate = null, string comments = null)
        {
            _logger.Info("Entering AddImmigration().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement ImmigrationMenu = Pages.Employee._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewImmigration/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                ImmigrationMenu.Click();
                Pages.Immigration.AddImmigrationRecord(document, docNumber, issueDate, expiryDate, eligibilityStatus, issuedBy, eligibilityReviewDate, comments);
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting AddImmigration().");
            }
        }

        public void EditSalary(string eeID)
        {
            _logger.Info("Entering EditSalary().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement SalaryMenu = _driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewSalaryList/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                SalaryMenu.Click();
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting EditSalary().");
            }
        }

        public void EditReportTo(string eeID)
        {
            _logger.Info("Entering EditReportTo().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement ReportToMenu = _driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewReportToDetails/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                ReportToMenu.Click();
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting EditReportTo().");
            }
        }

        public void EditQualifications(string eeID)
        {
            _logger.Info("Entering EditQualifications()");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement QualificationsMenu = _driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewQualifications/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                QualificationsMenu.Click();
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting EditQualifications().");
            }
        }

        public void EditMemberships(string eeID)
        {
            _logger.Info("Entering EditMemberships().");
            try
            {
                _logger.Info($"Searching for Employee with ID: {eeID}.");
                IWebElement MembershipsMenu = _driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewMemberships/empNumber/" + eeID + "']"));
                _logger.Info($"Employee with ID: {eeID} found.");
                MembershipsMenu.Click();
            }
            catch
            {
                _logger.Info("Could not find Employee..");
                throw new Exception($"The Employee with ID: {eeID} was not found.");
            }
            finally
            {
                _logger.Info("Exiting EditMemberships().");
            }
        }
    }
}
