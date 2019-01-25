using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddJob : BaseTest
    {
        [Test]
        [Description("Add a Job for Test Ess User")]
        public void AddJobToExistingEE()
        {
            string eeName = "Test Ess";

            // Job data
            #region
            string jobTitle = "IT Manager";
            string empStatus = "Full-Time Permanent";
            string jobCat = "Officials and Managers";
            string joinDate = "2015-01-31";
            string subUnit = "IT";
            string location = "HQ - CA, USA";
            string ecStartDate = "";
            string ecEndDate = "";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddJob(EmployeeList.SelectEmployeeInTableById(), jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate);
            Assert.IsTrue(Job.JobCorrectlyAdded(jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate), "Job was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add a Contract Job for a new EE")]
        public void AddContractorJob()
        {
            // Contractor data
            #region
            string userName = "";
            string password = "";
            string firstName = "Charlotte";
            string middleName = "Elise";
            string lastName = "Anderson";
            bool createLoginDetails = false;
            string statusEnabled = "";
            string eeName = firstName + " " + middleName + " " + lastName;
            #endregion

            // Job data
            #region
            string jobTitle = "Account Clerk";
            string empStatus = "Full-Time Contract";
            string jobCat = "Office and Clerical Workers";
            string joinDate = "2018-01-01";
            string subUnit = "Finance";
            string location = "New York Sales Office";
            string ecStartDate = "2018-01-01";
            string ecEndDate = "2019-12-31";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();
            //AdminLandingPage.NavigateToEmployeeList();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            //AdminLandingPage.NavigateToEmployeeList();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddJob(EmployeeList.SelectEmployeeInTableById(), jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate);
            Assert.IsTrue(Job.JobCorrectlyAdded(jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate), "Job was not added successfully.");

            Home.Logout();
        }


    }
}
