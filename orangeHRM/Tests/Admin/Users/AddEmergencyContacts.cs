using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddEmergencyContacts : BaseTest
    {
        [Test]
        [Description("Add an Emergency Contact for Test Ess User contact details new data")]
        public void AddEmergencyContactFullData()
        {
            string eeName = "Test Ess";
            // Emergency contact data
            #region
            string name = "Ellen V Johnson";
            string relationship = "Spouse";
            string homePhone = "303-555-1212";
            string mobilePhone = "303-555-2222";
            string workPhone = "303-555-3333";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddEmergencyContact(EmployeeList.SelectEmployeeInTableById(), name, relationship, homePhone, mobilePhone, workPhone);
            Assert.IsTrue(AssignEmergencyContacts.EmergencyContactCorrectlyAdded(name, relationship, homePhone, mobilePhone, workPhone), "Emergency Contact was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add an Emergency Contact for Test Ess User with Home Phone")]
        public void AddEmergencyContactHomePhone()
        {
            string eeName = "Test Ess";

            // Emergency contact data
            #region
            string name = "Sylvia Johnson";
            string relationship = "Mother";
            string homePhone = "303-555-3000";
            string mobilePhone = "";
            string workPhone = "";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddEmergencyContact(EmployeeList.SelectEmployeeInTableById(), name, relationship, homePhone, mobilePhone, workPhone);
            Assert.IsTrue(AssignEmergencyContacts.EmergencyContactCorrectlyAdded(name, relationship, homePhone, mobilePhone, workPhone), "Emergency Contact was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add an Emergency Contact for Test Ess User with Mobile Phone")]
        public void AddEmergencyContactMobilePhone()
        {
            string eeName = "Test Ess";

            // Emergency contact data
            #region
            string name = "Steven Allen Johnson";
            string relationship = "Father";
            string homePhone = "";
            string mobilePhone = "303-555-4000";
            string workPhone = "";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddEmergencyContact(EmployeeList.SelectEmployeeInTableById(), name, relationship, homePhone, mobilePhone, workPhone);
            Assert.IsTrue(AssignEmergencyContacts.EmergencyContactCorrectlyAdded(name, relationship, homePhone, mobilePhone, workPhone), "Emergency Contact was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add an Emergency Contact for Test Ess User with Work Phone")]
        public void AddEmergencyContactWorkPhone()
        {
            string eeName = "Test Ess";

            // Emergency contact data
            #region
            string name = "Robert Wilson Johnson";
            string relationship = "Son";
            string homePhone = "";
            string mobilePhone = "";
            string workPhone = "561-555-5000";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddEmergencyContact(EmployeeList.SelectEmployeeInTableById(), name, relationship, homePhone, mobilePhone, workPhone);
            Assert.IsTrue(AssignEmergencyContacts.EmergencyContactCorrectlyAdded(name, relationship, homePhone, mobilePhone, workPhone), "Emergency Contact was not added successfully.");

            Home.Logout();
        }
    }
}
