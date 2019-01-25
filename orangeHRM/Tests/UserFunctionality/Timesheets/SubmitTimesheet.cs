using NUnit.Framework;
using OrangeHRM.PageObjects;
using System.Configuration;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class SubmitTimesheet : BaseTest
    {
         // User data
        #region
        private string _userName = "stevejohnson";
        private string _password = "stevejohnson01";
        private string _firstName = "Steve";
        private string _middleName = "A";
        private string _lastName = "Johnson";
        private bool _createLoginDetails = true;
        private string _statusEnabled = "Enabled";

        private string _projectName = "Advanced C# Automation";
        
        private string _projectDescription = "This is an automation project.";
        private string _activityName1 = "Framework Development";
        private string _activityName2 = "Testcase Development";

        // Customer data
        private string _customerName = "Software Quality Unlimited";
        private string _customerDescription = "This is a test customer, please do not delete!";
        #endregion

        [SetUp]      
        public void SetupTimesheetPeriod()
        {
            string firstDayOfWeek = "Monday";


            #region
            

            // Project Data
            string projectAdmin = _firstName + " " + _middleName + " " + _lastName;
            #endregion

            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(_firstName, _middleName, _lastName, _createLoginDetails, _userName, _password, _statusEnabled);

            Menu.Time.GoTo();

            // Test to see if FirstDayOfWeek exists, if it does set it to Monday
            if (Time.DefineTimesheetPeriod.IsDefineTimesheetPeriodDisplayed() == true)
            {
                Time.SetFirstDayOfWeek(firstDayOfWeek);
            }

            // Setup Project
            // Add new Customer
            Menu.Time.ProjectInfo.Customers.GoTo();
            Customers.AddNewCustomer(_customerName, _customerDescription);

            // Add Project and create new customer
            Menu.Time.ProjectInfo.Projects.GoTo();
            Projects.AddNewProject(_customerName, _projectName, projectAdmin, _projectDescription);
            Projects.AddProjectActivity(_activityName1);
            Projects.AddProjectActivity(_activityName2);

            Home.Logout();
        }
        
        [Test]
        [Description("Create a new ESS User")]
        public void CreateMultipleTimesheetEntriesforESSUserAndSubmit()
        {
            string projectName = _customerName + " - " + _projectName;
            // Login as ESS user
            Home.Login(_userName, _password);

            Menu.Time.Timesheets.MyTimesheets.GoTo();

            // Note the format for locating the row in the timesheet table is _customerName + " - " + _projectName
            Time.EditTimesheet.AddRow(_customerName, _activityName1, 8.0, 8.0, 8.0, 0.0, 0.0, 0.0, 0.0);

            Time.EditTimesheet.AddRow(_customerName, _activityName2, 0.0, 0.0, 0.0, 8.0, 8.0, 0.0, 0.0);

            Time.EditTimesheet.SubmitTimesheet();

            Home.Logout();
        }

        [Test]
        [Description("Create a new ESS User")]
        public void CreateASecondTimesheetEntryforESSUser()
        {
            string projectName = _customerName + " - " + _projectName;
            // Login as ESS user
            Home.Login(_userName, _password);

            Menu.Time.Timesheets.MyTimesheets.GoTo();

            // Note the format for locating the row in the timesheet table is _customerName + " - " + _projectName
            Time.EditTimesheet.AddRow(_customerName, _activityName2, 0.0, 0.0, 0.0, 8.0, 8.0, 0.0, 0.0);

            Home.Logout();
        }
    }
}
