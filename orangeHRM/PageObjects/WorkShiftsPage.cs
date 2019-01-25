using System;
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
    public class WorkShifts : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "workShift_name")]
        [CacheLookup]
        public IWebElement ShiftName { get; set; }

        [FindsBy(How = How.Id, Using = "workShift_workHours_from")]
        [CacheLookup]
        public IWebElement From { get; set; }

        [FindsBy(How = How.Id, Using = "workShift_workHours_to")]
        [CacheLookup]
        public IWebElement To { get; set; }

        [FindsBy(How = How.Id, Using = "workShift_availableEmp")]
        [CacheLookup]
        public IWebElement AvailableEmployees { get; set; }

        [FindsBy(How = How.Id, Using = "workShift_assignedEmp")]
        [CacheLookup]
        public IWebElement AssignedEmployees { get; set; }

        [FindsBy(How = How.Id, Using = "btnAssignEmployee")]
        [CacheLookup]
        public IWebElement AddEmployeeBtn { get; set; }

        [FindsBy(How = How.Id, Using = "btnRemoveEmployee")]
        [CacheLookup]
        public IWebElement RemoveEmployeeBtn { get; set; }

        #endregion

        internal static void AddWorkShift(string shiftName, string from, string to)
        {
            _logger.Info("Entering AddWorkShift().");
            try
            {
                Pages.WorkShifts.AddBtn.Click();

                Pages.WorkShifts.ShiftName.Clear();
                Pages.WorkShifts.ShiftName.SendKeys(shiftName + Keys.Tab);
                Pages.WorkShifts.From.SendKeys(from + Keys.Tab);
                Pages.WorkShifts.To.SendKeys(to + Keys.Tab);

                Pages.WorkShifts.SaveBtn.Click();
            }
            catch(Exception ex)
            {
                throw new Exception($"A problem was encountered trying to Add a Work Shift: {ex}");
            }
            finally
            {
                _logger.Info("Exiting AddWorkShift().");
            }
        }

        internal static void DeleteWorkShift(string shiftName)
        {
            _logger.Info("Entering DeleteWorkShift().");

            try
            {
                // Locate the pay grade
                int workShiftRow = Pages.WorkShifts.SearchForRowContainingRecord(shiftName, "resultTable");

                Pages.WorkShifts._driver.FindElement(By.XPath($"//tbody/tr[{workShiftRow}]/td")).Click();
                Pages.WorkShifts.DeleteBtn.Click();

                // Respond to confirmation dialog
                Pages.Dialog.OkButton.Click();
            }
            catch
            {
                throw new Exception($"The expected Work Shift: {shiftName} could not be found!");
            }
            finally
            {
                _logger.Info("Exiting DeleteWorkShift().");
            }
        }

        internal static bool? WorkShiftEmployeesCorrectlyRemoved(string shiftName, string[] employees)
        {
            _logger.Info("Entering WorkShiftEmployeesCorrectlyRemoved().");

            try
            {
                WebDriverWait wait = new WebDriverWait(Pages.WorkShifts._driver, TimeSpan.FromSeconds(4));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(shiftName))).Click();

                Thread.Sleep(3000);

                SelectElement element = new SelectElement(Pages.WorkShifts.AvailableEmployees);
                foreach (string employee in employees)
                {
                    // if any employee has not been moved back then return false
                    try
                    {
                        element.SelectByText(employee);
                    }
                    catch
                    {
                        return false;
                    }  
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"A problem was encountered trying to verify an employee was removed from a work shift: {ex}!");
            }
            finally
            {
                _logger.Info("Exiting WorkShiftEmployeesCorrectlyRemoved().");
            }
        }

        internal static void DeleteEmployeeFromWorkShift(string shiftName, string[] employees)
        {
            _logger.Info("Entering DeleteEmployeeFromWorkShift().");

            try
            {
                WebDriverWait wait = new WebDriverWait(Pages.WorkShifts._driver, TimeSpan.FromSeconds(4));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(shiftName))).Click();

                Thread.Sleep(3000);

                SelectElement element = new SelectElement(Pages.WorkShifts.AssignedEmployees);
                foreach (string employee in employees)
                {
                    element.SelectByText(employee);
                    Pages.WorkShifts.RemoveEmployeeBtn.Click();
                }

                Pages.WorkShifts.SaveBtn.Click();
            }
            catch (Exception ex)
            {
                throw new Exception($"A problem was encountered trying to remove an employee from a work shift: {ex}!");
            }
            finally
            {
                _logger.Info("Exiting DeleteEmployeeFromWorkShift().");
            }
        }

        internal static bool? WorkShiftCorrectlyDeleted(string shiftName)
        {
            _logger.Info("Entering WorkShiftCorrectlyDeleted().");
            try
            {
                int workShiftRow = Pages.WorkShifts.SearchForRowContainingRecord(shiftName, "resultTable");
                return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                _logger.Info("Exiting WorkShiftCorrectlyDeleted().");
            }
        }

        internal static bool? WorkShiftCorrectlyAdded(string shiftName, string from, string to)
        {
            _logger.Info("Entering WorkShiftCorrectlyAdded().");

            // Calculate Hours Per Day
            string hrsPerDay = CalculateWorkHours(from, to);
            //Build an array of data used to run extracted data against
            string[] workShiftData = new string[] { "", shiftName, from, to, hrsPerDay };

            try
            {
                _logger.Info("Getting index of row containing Job Titler.");

                int workShiftRow = Pages.WorkShifts.SearchForRowContainingRecord(shiftName, "resultTable");
                // Getting the elements in the row
                IList<IWebElement> TableData = Pages.WorkShifts._driver.FindElements(By.XPath($"//tbody/tr[{workShiftRow}]/td"));

                //Build a list of extracted elements from table
                List<string> items = new List<string>();
                foreach (IWebElement item in TableData)
                {
                    if ((item.Text != "") || (item.Text != null))
                        items.Add(item.Text);
                }
                return Enumerable.SequenceEqual(items, workShiftData);
            }
            catch
            {
                _logger.Info("The Work Shift was not added correctly.");
                return false;
            }
            finally
            {
                _logger.Info("Exiting WorkShiftCorrectlyAdded().");
            }
        }

        internal static bool? WorkShiftEmployeesCorrectlyAdded(string shiftName, string[] employees)
        {
            _logger.Info("Entering WorkShiftEmployeesCorrectlyAdded().");

            try
            {
                WebDriverWait wait = new WebDriverWait(Pages.WorkShifts._driver, TimeSpan.FromSeconds(4));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(shiftName))).Click();
                
                Thread.Sleep(3000);
                
                SelectElement element = new SelectElement(Pages.WorkShifts.AssignedEmployees);
                foreach (string employee in employees)
                {
                    try
                    {
                        element.SelectByText(employee);
                    }
                    catch
                    {
                        return false;
                    }
                    
                }
                return true;
                
            }
            catch (Exception ex)
            {
                throw new Exception($"A problem was encountered trying to add an employee to a work shift: {ex}!");
            }
            finally
            {
                _logger.Info("Exiting WorkShiftEmployeesCorrectlyAdded().");
            }
        }

        internal static void AssignEmployeeToWorkShift(string shiftName, string[] employees)
        {
            _logger.Info("Entering AssignEmployeeToWorkShift().");

            try
            {
                WebDriverWait wait = new WebDriverWait(Pages.WorkShifts._driver, TimeSpan.FromSeconds(4));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText(shiftName))).Click();

                Thread.Sleep(3000);

                SelectElement element = new SelectElement(Pages.WorkShifts.AvailableEmployees);
                foreach (string employee in employees)
                {
                    element.SelectByText(employee);
                    Pages.WorkShifts.AddEmployeeBtn.Click();
                }

                Pages.WorkShifts.SaveBtn.Click();
            }
            catch(Exception ex)
            {
                throw new Exception($"A problem was encountered trying to add an employee to a work shift: {ex}!");
            }
            finally
            {
                _logger.Info("Exiting AssignEmployeeToWorkShift().");
            }
        }

        private static string CalculateWorkHours(string from, string to)
        {
            _logger.Info("Entering CalculateWorkHours()");

            DateTime startTime = Convert.ToDateTime(from);
            DateTime endTime = Convert.ToDateTime(to);
            TimeSpan duration = endTime - startTime;

            _logger.Info("Exiting CalculateWorkHours()");

            return duration.ToString(@"h\.mm");
        }

    }
}