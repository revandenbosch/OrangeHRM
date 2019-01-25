using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace OrangeHRM.PageObjects
{
    public class Menu
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private const int _timeout = 2;
        
         // Page object definitions
        #region
        public IList<IWebElement> MenuItems => _driver.FindElements(By.ClassName("firstLevelMenu"));
        #endregion

        public class Admin
        {
            public class UserManagement
            {

                public class Users
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "User Management", "Users");
                    }
                }
            }

            public class Job
            {

                public class JobTitles
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Job", "Job Titles");
                    }
                }

                public class PayGrades
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Job", "Pay Grades");
                    }
                }

                public class EmploymentStatus
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Job", "Employment Status");
                    }
                }

                public class JobCategories
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Job", "Job Categories");
                    }
                }

                public class WorkShifts
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Job", "Work Shifts");
                    }
                }
            }

            public class Organization
            {
                public class GeneralInformation
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Organization", "General Information");
                    }
                }

                public class Locations
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Organization", "Locations");
                    }
                }

                public class Structure
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Organization", "Structure");
                    }
                }
            }

            public class Qualifications
            {
                public class Skills
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Qualifications", "Skills");
                    }
                }

                public class Education
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Qualifications", "Education");
                    }
                }

                public class Licenses
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Qualifications", "Licenses");
                    }
                }

                public class Languages
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Qualifications", "Languages");
                    }
                }

                public class Memberships
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Qualifications", "Memberships");
                    }
                }
            }

            public class Nationalities
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("Admin", "Nationalities");
                }
            }

            public class Configuration
            {
                public class EmailConfiguration
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Configuration", "Email Configuration");
                    }
                }

                public class EmailSubscriptions
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Configuration", "Email Subscriptions");
                    }
                }

                public class Localization
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Configuration", "Localization");
                    }
                }

                public class Modules
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Configuration", "Modules");
                    }
                }

                public class SocialMediaAuthentication
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Configuration", "Social Media Authentication");
                    }
                }

                public class RegisterOAthClient
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Admin", "Configuration", "Register OAuth Client");
                    }
                }
            }
        }

        public class PIM
        {
            public class Configuration
            {
                public class OptionalFields
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("PIM", "Configuration", "Optional Fields");
                    }
                }

                public class CustomFields
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("PIM", "Configuration", "Custom Fields");
                    }   
                }

                public class DataImport
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("PIM", "Configuration", "Data Import");
                    }
                }

                public class ReportingMethods
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("PIM", "Configuration", "Reporting Methods");
                    }
                }

                public class TerminationReasons
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("PIM", "Configuration", "Termination Reasons");
                    }
                }
            }

            public class EmployeeList
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("PIM", "Employee List", "null");
                }
            }

            public class AddEmployee
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("PIM", "Add Employee", "null");
                }
            }

            public class Reports
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("PIM", "Reports", "null");
                }
            }
        }

        public class Leave
        {
            public class Entitlements
            {
                public class AddEntitlements
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Entitlements", "Add Entitlements");
                    }
                }

                public class EmployeeEntitlements
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Entitlements", "Employee Entitlements");
                    }
                }

            }

            public class Reports
            {
                public class LeaveEntitlementsAndUsageReport
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Reports", "Leave Entitlements and Usage Report");
                    }
                }
            }

            public class Configure
            {
                public class LeavePeriod
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Configure", "Leave Period");
                    }
                }

                public class LeaveTypes
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Configure", "Leave Types");
                    }
                }

                public class WorkWeek
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Configure", "Work Week");
                    }
                }

                public class Holidays
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Leave", "Configure", "Holidays");
                    }
                }
            }

            public class LeaveList
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("Leave", "Leave List", "null");
                }
            }

            public class  AssignLeave
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("Leave", "Assign Leave", "null");
                }
            }
        }

        public class Time
        {
            public static void GoTo()
            {
                Pages.Menu.MouseHover_SubMenusClick("Time", "null", "null");
            }

            public class Timesheets
            {
                public class EmployeeTimesheets
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Timesheets", "Employee Timesheets");
                    }
                }

                public class MyTimesheets
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Timesheets", "My Timesheets");
                    }
                }
            }

            public class Attendance
            {
                public class EmmployeeRecords
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Attendence", "Employee Records");
                    }
                }

                public class Configuration
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Attendence", "Configuration");
                    }
                }

                public class MyRecords
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Attendence", "My Records");
                    }
                }

                public class PunchInOut
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Attendence", "Punch In/Out");
                    }
                }
            }

            public class Reports
            {
                public class ProjectReports
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Reports", "Project Reports");
                    }
                }

                public class EmployeeReports
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Reports", "Employee Reports");
                    }
                }

                public class AttendanceSummary
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Reports", "Attendance Summary");
                    }
                }
            }

            public class ProjectInfo
            {
                public class Customers
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Project Info", "Customers");
                    }
                }

                public class Projects
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Time", "Project Info", "Projects");
                    }
                }
            }
        }

        public class Recruitment
        {
            public class Candidates
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("Recruitment", "Candidates", "null");
                }
            }

            public class Vacancies
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("Recruitment", "Vacancies", "null");
                }
            }
        }

        public class Performance
        {
            public class Configure
            {
                public class KPIS
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Performance", "Configure", "KPIs");
                    }
                }

                public class Trackers
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Performance", "Configure", "Trackers");
                    }
                }
            }

            public class ManageReviews
            {
                public class ManageReview
                {
                    public static void GoTo()
                    {
                        Pages.Menu.MouseHover_SubMenusClick("Performance", "Manage Reviews", "Manage Reviews");
                    }
                }

            }

            public class EmployeeTrackers
            {
                public static void GoTo()
                {
                    Pages.Menu.MouseHover_SubMenusClick("Performance", "Employee Trackers", "null");
                }
            }
        }

        public class Dashboard
        {
            public static void GoTo()
            {
                Pages.Menu.MouseHover_SubMenusClick("Dashboard", "null", "null");
            }
        }

        public class Directory
        {
            public static void GoTo()
            {
                Pages.Menu.MouseHover_SubMenusClick("Directory", "null", "null");
            }
        }

        public void MouseHover_SubMenusClick(string primaryMenu, string subMenu = null, string subSubMenu = null)
        {
            //Doing a MouseHover  
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout));
            _logger.Info($"Locating top level menu item: {primaryMenu}.");
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), '" + primaryMenu + "')]")));
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
            if ((subMenu == null) || (subMenu == "null"))
            {
                _logger.Info($"Clicking on top level menu item: {primaryMenu}. No submenues.");
                element.Click();
            }
            else
            {
                //Clicking the SubMenu on MouseHover   
                if ((subSubMenu == null) || (subSubMenu == "null"))
                {
                    _logger.Info($"Locating top level menu item: {primaryMenu} and sub-menu item: {subMenu}.");
                    var subMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), '" + subMenu + "')]")));
                    Actions action2 = new Actions(_driver);
                    action2.MoveToElement(subMenuElement).Build().Perform();
                    _logger.Info($"Clicking on top level menu item: {primaryMenu} and sub-menu item: {subMenu}.");
                    subMenuElement.Click();
                } //Clicking the SubSubMenu on MouseHover 
                else
                {
                    _logger.Info($"Locating top level menu item: {primaryMenu}, sub-menu item: {subMenu} and subsub-menu item: {subSubMenu}.");
                    if (subMenu == "Project Info")
                    {
                        var subMenuElement1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@id, 'menu_admin" + "_" + subMenu.Replace(" ", "") + "')]")));
                        Actions action1 = new Actions(_driver);
                        action1.MoveToElement(subMenuElement1).Perform();
                    }
                    else
                    {
                        var subMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@id, 'menu_" + primaryMenu.ToLower() + "_" + subMenu.Replace(" ", "") + "')]")));
                        Actions action2 = new Actions(_driver);
                        action2.MoveToElement(subMenuElement).Perform();
                    }
                    //I had to write this try/catch because I could not come up with an xpath to 
                    // use this <a href="/index.php/performance/searchPerformancReview" id="menu_performance_searchPerformancReview">Manage Reviews</a>
                    try
                    {
                        var subSubMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@id = 'menu_performance_searchPerformancReview']")));
                        Actions action3 = new Actions(_driver);
                        action3.MoveToElement(subSubMenuElement).Perform();
                        _logger.Info($"Clicking on top level menu item: {primaryMenu}, sub-menu item: {subMenu} and subsub-menu item: {subSubMenu}. Specifically for Manage Reviews");
                        subSubMenuElement.Click();
                    }
                    catch
                    {
                        var subSubMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), '" + subSubMenu + "')]")));
                        Actions action3 = new Actions(_driver);
                        action3.MoveToElement(subSubMenuElement).Perform();
                        _logger.Info($"Clicking on top level menu item: {primaryMenu}, sub-menu item: {subMenu} and subsub-menu item: {subSubMenu}.");
                        subSubMenuElement.Click();
                    }

                }
            }
        }

        public bool IsCorrectPageDispayed(string pageName)
        {
            IWebElement ScreenTitle = _driver.FindElement(By.XPath("//h1[contains(text(),'" + pageName + "')]"));
            return ScreenTitle.Displayed;
        }
    }
}
