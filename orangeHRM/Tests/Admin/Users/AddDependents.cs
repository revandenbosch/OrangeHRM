using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddDependents : BaseTest
    {
        [Test]
        [Description("Add a child Dependent for Test Ess User")]
        public void AddChildDependent()
        {
            string eeName = "Test Ess";
            // Dependent data
            #region
            string name = "Robert Wilson Johnson";
            string relationship = "Child";
            string dob = "2010-04-06";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddDependent(EmployeeList.SelectEmployeeInTableById(), name, relationship, "" , dob);
            Assert.IsTrue(AssignDependent.DependentCorrectlyAdded(name, relationship, "", dob), "Dependent was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add a child Dependent for Test Ess User w/o DOB")]
        public void AddChildDependentWODob()
        {
            string eeName = "Test Ess";

            // Dependent data
            #region
            string name = "Caroline Ann Johnson";
            string relationship = "Child";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddDependent(EmployeeList.SelectEmployeeInTableById(), name, relationship);
            Assert.IsTrue(AssignDependent.DependentCorrectlyAdded(name, relationship), "Dependent was not added successfully.");

           Home.Logout();
        }

        [Test]
        [Description("Add an Other Dependent for Test Ess User")]
        public void AddOtherDependent()
        {
            string eeName = "Test Ess";

            // Dependent data
            #region
            string name = "Ellen V Johnson";
            string relationship = "Other";
            string dob = "1950-12-29";
            string other = "Spouse";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddDependent(EmployeeList.SelectEmployeeInTableById(), name, relationship, other, dob);
            Assert.IsTrue(AssignDependent.DependentCorrectlyAdded(name, relationship, other, dob), "Dependent was not added successfully.");

            Home.Logout();
        }
    }
}
