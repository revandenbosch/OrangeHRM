using System;
using System.Threading;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class EmployeeList : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "menu_pim_viewEmployeeList")]
        [CacheLookup]
        public IWebElement EmployeeListPimSubMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "menu_pim_addEmployee")]
        [CacheLookup]
        private IWebElement AddEmployeePimSubMenuItem { get; set; }

        [FindsBy(How = How.Id, Using = "empsearch_employee_name_empName")]
        [CacheLookup]
        public IWebElement EmployeeName { get; set; }

        [FindsBy(How = How.Id, Using = "empsearch_termination")]
        [CacheLookup]
        public IWebElement Include { get; set; }

        [FindsBy(How = How.Id, Using = "empseach_Id")]
        [CacheLookup]
        private IWebElement Id { get; set; }

        [FindsBy(How = How.Id, Using = "searchBtn")]
        [CacheLookup]
        public IWebElement Search { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='chkSelectRow[]']")]
        [CacheLookup]
        public IWebElement CheckBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='chkSelectRow[]']")]
        [CacheLookup]
        public IWebElement ID { get; set; }   
        #endregion

        public static void SearchForEmployee(string eeName, string iD = null, string employmentStatus = "All", string include = "Current Employees Only",
            string supName = "", string title = "All", string subUnit = "All")
        {
            _logger.Info("Entering SearchForEmployee()");
            Thread.Sleep(3000);
            Pages.EmployeeList.EmployeeName.SendKeys(eeName);
            Pages.EmployeeList.EmployeeName.SendKeys(Keys.Tab);
            Pages.EmployeeList.Include.SendKeys(include + Keys.Tab);
            Pages.EmployeeList.Search.Click();
            _logger.Info("Exiting SearchForEmployee()");
        }

        public static void SearchForPastEmployee(string eeName)
        {

            _logger.Info($"SearchForPastEmployee called with: {eeName}.)");

            _logger.Info("PIM->Employee List selected.");

            SearchForEmployee(eeName, include: "Past Employees Only");
        }

        public static void SelectEmployeeInTableUsingCheckBox()
        {
            _logger.Info("Entering SelectEmployeeInTableUsingCheckBox()");

            Table w3cTable = new Table(Pages.EmployeeList._driver.FindElement(By.Id("search-results")));
            int numRows = w3cTable.RowCount();
            if (numRows == 1)
            {
                Pages.EmployeeList.CheckBox.Click();
            }
            else
            {
                //More than one EE matched the search
                throw new NotImplementedException();
            }
            _logger.Info("Exiting SelectEmployeeInTableUsingCheckBox()");
        }

        public static string SelectEmployeeInTableById()
        {
            _logger.Info("Entering SelectEmployeeInTableById()");
            Table w3cTable = new Table(Pages.EmployeeList._driver.FindElement(By.Id("search-results")));
            int numRows = w3cTable.RowCount();
            if (numRows == 1)
            {
                //string ID = _driver.FindElement(By.XPath("//input[@name='chkSelectRow[]']")).GetAttribute("value");
                string ID = Pages.EmployeeList.ID.GetAttribute("value");

                IWebElement id = Pages.EmployeeList._driver.FindElement(By.XPath("//a[@href='/index.php/pim/viewEmployee/empNumber/" +
                    Pages.EmployeeList._driver.FindElement(By.XPath("//input[@name='chkSelectRow[]']")).GetAttribute("value") + "']"));
                id.Click();
                _logger.Info("Exiting SelectEmployeeInTableById()");
                //return Pages.EmployeeList.ID.ToString();
                return ID; //.ToString();
            }
            else
            {
                //More than one EE matched the search
                throw new NotImplementedException();
            }
        }

        public static void AddEmployeeViaButton(string firstName, string middleName, string lastName, bool createLoginDetails = false, string userName = "", string password = "", string statusEnabled = "Enabled")
        {
            _logger.Info("Entering AddEmployeeViaButton()");

            Pages.EmployeeList.AddBtn.Click();
            Pages.AddEmployee.AddAnEmployee(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);

            _logger.Info("Exiting AddEmployeeViaButton()");
        }

        public static void DeleteEmployee(string firstName, string middleName, string lastName)
        {
            _logger.Info("Entering DeleteEmployee()");

            string employeeName = firstName + " " + middleName + " " + lastName;

            try
            {
                SearchForEmployee(employeeName);
                SelectEmployeeInTableUsingCheckBox();

                Pages.EmployeeList.DeleteBtn.Click();
                Pages.Dialog.OkButton.Click();
            }
            catch(Exception ex)
            {
                throw new Exception($"A problem was encountered trying to delete employee: {employeeName}! error: {ex}");
            }
            finally
            {
                _logger.Info("Exiting DeleteEmployee()");
            }
            
            
        }
    }
}