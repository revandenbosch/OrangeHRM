using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class VerifyESSDashboard : BaseTest
    {
        [Test]
        [Description("Verify ESS Dashboard main elements.")]
        public void VerifyESSDashboardElements()
        {
            #region
            string[] expectedData = new string[] { "Quick Launch"};
            string firstName = "Michael";
            string middleName = "W";
            string lastName = "Smith";
            bool createLoginDetails = true;
            string userName = "mwsmith";
            string password = "mwsmith01";
            string statusEnabled = "Enabled";
            #endregion

            // Cretae an ESS user
            Home.GoTo();
            Home.LoginAsAdmin();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            Home.Logout();

            // Login as ESS user
            //Home.GoTo();
            Home.Login(userName, password);

            Menu.Dashboard.GoTo();

            Assert.IsTrue(Dashboard.ESSDashboard.HasCorrectPanels(expectedData), "The ESS Dashboard is missing expected panels!");

            Home.Logout();

            // Delete ESS User
            //Home.GoTo();
            //Home.LoginAsAdmin();
            //Menu.PIM.EmployeeList.GoTo();
            //EmployeeList.DeleteEmployee();

            //Home.Logout();
        }

        [Test]
        [Description("Verify ESS Dashboard Quick Launch elements.")]
        public void VerifyESSDashboardQuickLaunchElements()
        {
            #region
            string[] expectedData = new string[] { "Apply Leave", "My Leave", "My Timesheet" };

            string firstName = "Karen";
            string middleName = "Ann";
            string lastName = "Smith";
            bool createLoginDetails = true;
            string userName = "kasmith";
            string password = "kasmith01";
            string statusEnabled = "Enabled";

            #endregion
            // Cretae an ESS user
            Home.GoTo();
            Home.LoginAsAdmin();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            Home.Logout();

            // Login as ESS user
            //Home.GoTo();
            Home.Login(userName, password);

            Menu.Dashboard.GoTo();

            Assert.IsTrue(Dashboard.ESSDashboard.HasCorrectQuickLaunchOptions(expectedData), "The ESS Dashboard is missing expected panels!");

            Home.Logout();
        }

        [Test]
        [Description("Verify ESS Dashboard Quick Launch Apply Leave.")]
        public void VerifyESSDashboardQuickLaunchApplyLeave()
        {
            #region
            string firstName = "Olive";
            string middleName = "Ann";
            string lastName = "Smith";
            bool createLoginDetails = true;
            string userName = "oasmith";
            string password = "oasmith01";
            string statusEnabled = "Enabled";

            string pageName = "Apply Leave";
            #endregion

            // Cretae an ESS user
            Home.GoTo();
            Home.LoginAsAdmin();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            Home.Logout();

            // Login as ESS user
            //Home.GoTo();
            Home.Login(userName, password);

            Menu.Dashboard.GoTo();
            Dashboard.ESSDashboard.SelectApplyLeave();

            Assert.IsTrue(Dashboard.IsCorrectPage(pageName), "The Apply Leave link did not go to the expected screen!");

            Home.Logout();
        }

        [Test]
        [Description("Verify ESS Dashboard Quick Launch My Leave.")]
        public void VerifyESSDashboardQuickLaunchMyLeave()
        {
            #region
            string firstName = "James";
            string middleName = "A";
            string lastName = "Davis";
            bool createLoginDetails = true;
            string userName = "jadavis";
            string password = "jadavis01";
            string statusEnabled = "Enabled";

            string pageName = "My Leave List";
            #endregion

            // Cretae an ESS user
            Home.GoTo();
            Home.LoginAsAdmin();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            Home.Logout();

            // Login as ESS user
            //Home.GoTo();
            Home.Login(userName, password);

            Menu.Dashboard.GoTo();
            Dashboard.ESSDashboard.SelectMyLeave();

            Assert.IsTrue(Dashboard.IsCorrectPage(pageName), "The My Leave link did not go to the expected screen!");

            Home.Logout();
        }

        [Test]
        [Description("Verify ESS Dashboard Quick Launch My Timesheet.")]
        public void VerifyESSDashboardQuickLaunchMyTimesheet()
        {
            #region
            string firstName = "Karen";
            string middleName = "Ann";
            string lastName = "Quinn";
            bool createLoginDetails = true;
            string userName = "kaquinn";
            string password = "kaquinn01";
            string statusEnabled = "Enabled";

            string pageName = "Timesheet for Week";
            #endregion

            // Cretae an ESS user
            Home.GoTo();
            Home.LoginAsAdmin();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            Home.Logout();

            // Login as ESS user
            //Home.GoTo();
            Home.Login(userName, password);

            Menu.Dashboard.GoTo();
            Dashboard.ESSDashboard.SelectMyTimesheet();

            Assert.IsTrue(Dashboard.IsCorrectPage(pageName), "The My Timesheet link did not go to the expected screen!");

            Home.Logout();
        }
    }
}
