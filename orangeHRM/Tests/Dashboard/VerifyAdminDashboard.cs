using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{ 
    [TestFixture]
    public class VerifyAdminDashboard : BaseTest
    {
        [Test]
        [Description("Verify Admin Dashboard main elements.")]
        public void VerifyAdminDashboardElements()
        {
            #region
            string[] expectedData = new string[] { "Quick Launch", "Employee Distribution by Subunit", "Legend", "Pending Leave Requests" };
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();
           
            Menu.Dashboard.GoTo();

            Assert.IsTrue(Dashboard.AdminDashboard.HasCorrectPanels(expectedData), "The Admin Dashboard is missing expected panels!");

            Home.Logout();
        }

        [Test]
        [Description("Verify Admin Dashboard Quick Launch elements.")]
        public void VerifyAdminDashboardQuickLaunchElements()
        {
            #region
            string[] expectedData = new string[] { "Assign Leave", "Leave List", "Timesheets" };
            #endregion


            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Dashboard.GoTo();
            Assert.IsTrue(Dashboard.AdminDashboard.HasCorrectQuickLaunchOptions(expectedData), "The Admin Dashboard is missing expected panels!");

            Home.Logout();
        }

        [Test]
        [Description("Verify Admin Dashboard EE pie chart # of segments matches number of keys in the Legend.")]
        public void VerifyAdminDashboardEEDistPieChart()
        {
            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Dashboard.GoTo();
            Assert.IsTrue(Dashboard.AdminDashboard.HasCorrectNumOfPieSegments(), "The Admin Dashboard is missing expected panels!");

            Home.Logout();
        }

        [Test]
        [Description("Verify Admin Dashboard Quick Launch Assign Leave.")]
        public void VerifyESSDashboardQuickLaunchApplyLeave()
        {
            #region
            string pageName = "Assign Leave";
            #endregion


            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Dashboard.GoTo();
            Dashboard.AdminDashboard.SelectAssignLeave();

            Assert.IsTrue(Dashboard.IsCorrectPage(pageName), "The Assign Leave link did not go to the expected screen!");

            Home.Logout();
        }

        [Test]
        [Description("Verify Admin Dashboard Quick Launch Leave List.")]
        public void VerifyESSDashboardQuickLaunchMyLeave()
        {
            #region
            string pageName = "Leave List";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Dashboard.GoTo();
            Dashboard.AdminDashboard.SelectLeaveList();

            Assert.IsTrue(Dashboard.IsCorrectPage(pageName), "The Leave List link did not go to the expected screen!");

            Home.Logout();
        }

        [Test]
        [Description("Verify Admin Dashboard Quick Launch Timesheets.")]
        public void VerifyESSDashboardQuickLaunchMyTimesheet()
        {
            #region
            string pageName = "Select Employee";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Dashboard.GoTo();
            Dashboard.AdminDashboard.SelectTimesheets();

            Assert.IsTrue(Dashboard.IsCorrectPage(pageName), "The Timesheets link did not go to the expected screen!");

            Home.Logout();
        }
    }
}
