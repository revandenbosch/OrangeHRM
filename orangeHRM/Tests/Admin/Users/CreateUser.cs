using NUnit.Framework;
using OrangeHRM.PageObjects;
using System.Configuration;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class CreateUser : BaseTest
    {
         // User data
        #region
        private string _userName = "TestESS";
        private string _password = "testess01";
        //private string _essName = "Test Ess User";
        private string _firstName = "Test";
        private string _middleName = "Ess";
        private string _lastName = "User";
        private bool _createLoginDetails = true;
        private string _statusEnabled = "Enabled";
        #endregion

        [SetUp]      
        public void CleanupESSUser()
        {
            try
            {
                //Home.GoTo();
                Home.Login(_userName, _password);
                
                // Test to see if user exists, if it does delete user
                Assert.IsTrue(Home.ValidateWarningMessage("Invalid credentials"), "ESS user already exists.");
            }
            // User exists so delete user
            catch
            {
                Home.Logout();

                // Delete existing ESS user
                Home.LoginAsAdmin();
                Menu.PIM.EmployeeList.GoTo();               
                EmployeeList.DeleteEmployee(_firstName, _middleName, _lastName);

                Home.Logout();
            }
        }
        
        [Test]
        [Description("Create a new ESS User")]
        public void CreateESSUser()
        {
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();

            EmployeeList.AddEmployeeViaButton(_firstName, _middleName, _lastName, _createLoginDetails, _userName, _password, _statusEnabled);

            Home.Logout();
        }
    }
}
