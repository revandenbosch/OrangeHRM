using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests.Login
{
    [TestFixture]
    public class Login : BaseTest //MultipleBrowserTesting//
    {
        [Test]
        [Description("Login With Valid Admin User")]
        public void LoginWithValidAdminUser()
        {
            Home.LoginAsAdmin();
            Assert.IsTrue(Home.LoginIsSuccessfull(), "Admin user was not successfully logged in.");
            Home.Logout();
        }

        [Test]
        [Description("Login With No User or Password")]
        public void LoginWithNoUserorPassword()
        {
            string userName = "";
            string password = "";
            string msg = "Username cannot be empty";

            Home.Login(userName, password);
            Assert.IsTrue(Home.ValidateWarningMessage(msg), "The correct Warning message was not displayed.");
        }

        [Test]
        [Description("Login With User And No Password")]
        public void LoginWithUserAndNoPassword()
        {
            string userName = "test";
            string password = "";
            string msg = "Password cannot be empty";

            Home.Login(userName, password);
            Assert.IsTrue(Home.ValidateWarningMessage(msg), "The correct Warning message was not displayed.");
        }

        [Test]
        [Description("Login With No User And A Password")]
        public void LoginWithNoUserAndAPassword()
        {
            string userName = "";
            string password = "";
            string msg = "Username cannot be empty";

            Home.Login(userName, password);
            Assert.IsTrue(Home.ValidateWarningMessage(msg), "The correct Warning message was not displayed.");
        }

        [Test]
        [Description("Login With Invalid User")]
        public void LoginWithInvalidUser()
        {
            string userName = "Dummy";
            string password = "password";
            string msg = "Invalid credentials";

            Home.Login(userName, password);
            Assert.IsTrue(Home.ValidateWarningMessage(msg), "The correct Warning message was not displayed.");
        }
    }
}
