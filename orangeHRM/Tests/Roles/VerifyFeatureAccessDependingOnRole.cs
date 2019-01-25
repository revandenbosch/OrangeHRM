using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    /// <summary>
    /// Summary description for Roles
    /// </summary>
    [TestFixture]
    public class Roles : BaseTest
    {
        private string[] _adminMenuItems = new string[] { "Admin", "PIM", "Leave", "Time", "Recruitment", "Performance", "Dashboard", "Directory" };

        private string[] _eSSMenuItems = new string[] { "Leave", "Time", "My Info", "Performance", "Dashboard", "Directory" };

        [Test]
        [Description("Verifies the correct Admin menu options are present.")]
        public void VerifyAdminRoleMenus()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Assert.IsTrue(AdminLanding.IsCorrectMenu(_adminMenuItems), "The Admin menu items did not match the expected values.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the correct ESS menu options are present.")]
        public void VerifyESSRoleMenus()
        {
            string userName = "TestESS";
            string password = "testess01";

            Home.GoTo();
            Home.Login(userName, password);
            Assert.IsTrue(EssLanding.IsCorrectMenu(_eSSMenuItems), "The ESS menu items did not match the expected values.");
            Home.Logout();
        }
    }
}
