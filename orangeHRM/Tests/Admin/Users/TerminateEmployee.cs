using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class TerminateEmployee : BaseTest
    {
        [Test]
        [Description("Terminate a an Employee who is retiring")]
        public void TerminateAnEmployee()
        {
            // New Employee data
            #region
            string userName = "twallace";
            string password = "twallace1";
            string firstName = "Thomas";
            string middleName = "E.";
            string lastName = "Wallace";
            bool createLoginDetails = true;
            string statusEnabled = "Enabled";
            string eeName = firstName + " " + middleName + " " + lastName;
            #endregion

            // Job data
            #region
            string jobTitle = "Finance Manager";
            string empStatus = "Full-Time Permanent";
            string jobCat = "Officials and Managers";
            string joinDate = "1995-06-01";
            string subUnit = "Finance";
            string location = "HQ - CA, USA";
            string ecStartDate = "";
            string ecEndDate = "";
            #endregion

            // Termination data
            #region
            string reason = "Retired";
            string date = "2018-11-30";
            string note = "";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create new Employee
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);
            
            // Add a job to the employee 
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddJob(EmployeeList.SelectEmployeeInTableById(), jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate);
            
            // Terminate the Employees employment
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.TerminateEmployee(EmployeeList.SelectEmployeeInTableById(), reason, date, note);
            Assert.IsTrue(Job.EmployeeTerminated(date), "Employee was not Terminated successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Terminate a Contract EE")]
        public void TerminateContractEmployee()
        {
            // New Employee data
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

            // Termination data
            #region
            string reason = "Contract Not Renewed";
            string date = "2019-12-31";
            string note = "Eligible for re-hire at another time.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create new Contract employee
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);

            // Add a job for the Contractor
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddJob(EmployeeList.SelectEmployeeInTableById(), jobTitle, empStatus, jobCat, joinDate, subUnit, location, ecStartDate, ecEndDate);

            // Terminate the Contractors employment
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.TerminateEmployee(EmployeeList.SelectEmployeeInTableById(), reason, date, note);
            Assert.IsTrue(Job.EmployeeTerminated(date), "Employee was not Terminated successfully.");

            Home.Logout();
        }


    }
}
