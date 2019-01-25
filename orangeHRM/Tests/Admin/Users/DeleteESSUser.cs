using NUnit.Framework;
using OrangeHRM.PageObjects;
using System.Configuration;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class DeleteESSUser : BaseTest
    {
         // User data
        #region
        private string _firstName = "Test";
        private string _middleName = "Ess";
        private string _lastName = "User";
        private bool _createLoginDetails = false;
        #endregion
     
        [Test]
        [Description("Delete an ESS User")]
        public void DeleteAnESSUser()
        {
            Home.LoginAsAdmin();

            // Create a user
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(_firstName, _middleName, _lastName, _createLoginDetails);

            // Delete a user
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.DeleteEmployee(_firstName, _middleName, _lastName);
            Home.Logout();
        }
    }
}
