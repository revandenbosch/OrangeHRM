using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class EditEmployeePersonalDetails : BaseTest
    {
        [Test]
        [Description("Edit an EES users persoanl details with new data")]
        public void EditPersonalDetails()
        {
            string eeName = "Test Ess";

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.EditPersonalDetails(EmployeeList.SelectEmployeeInTableById(), firstName: "Test", middleName: "Ess", lastName: "User", otherId: "EE11212018", driversLicense: "FL: S0123456",
            licenseExpDate: "2025-01-31", gender: "m", maritalStatus: "Married", nationality: "Italy", dob: "1952-06-12");

            Home.Logout();
        }
    }
}
