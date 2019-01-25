using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddSalary : BaseTest
    {
        [Test]
        [Description("Add a Base Salary for Test Ess User - No Direct Deposit")]
        public void AddSalaryToExistingEENoDirectDeposit()
        {
            string eeName = "Test Ess";

            // Salary components
            #region
            string payGrade = "Executive";
            string salaryComponent = "Base";
            string payFrequency = "Bi Weekly";
            string currency = "United States Dollar";
            string amount = "75000";
            string comments = "Base salary and No commission.";
            bool directDeposit = false;
            string accountNumber = "";
            string accountType = "";
            string pleaseSpecify = "";
            string routingNumber = "";
            decimal amountDeposit = 0.00m;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddSalary(EmployeeList.SelectEmployeeInTableById(), payGrade, salaryComponent, currency, amount, 
                directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments);
            Assert.IsTrue(AssignedSalaryComponents.SalaryCorrectlyAdded(payGrade, salaryComponent, currency, amount, directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments), "Salary was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add a Base Salary for Test Ess User - Direct Deposit")]
        public void AddSalaryToExistingEEDirectDeposit()
        {
            string eeName = "Test Ess";

            // Salary components
            #region
            string payGrade = "Executive";
            string salaryComponent = "Base";
            string payFrequency = "Monthly";
            string currency = "United States Dollar";
            string amount = "55000";
            string comments = "Base salary.";
            bool directDeposit = true;
            string accountNumber = "123456789";
            string accountType = "Checking";
            string pleaseSpecify = "";
            string routingNumber = "987654321";
            decimal amountDeposit = 5000.00m;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddSalary(EmployeeList.SelectEmployeeInTableById(), payGrade, salaryComponent, currency, amount,
                directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments);
            Assert.IsTrue(AssignedSalaryComponents.SalaryCorrectlyAdded(payGrade, salaryComponent, currency, amount, directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments), "Salary was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add a Base Salary for Test Ess User - Direct Deposit to Other Account")]
        public void AddSalaryToExistingEEDirectDepositOtherAcct()
        {
            string eeName = "Test Ess";

            // Salary components
            #region
            string payGrade = "";
            string salaryComponent = "Base";
            string payFrequency = "Monthly";
            string currency = "United States Dollar";
            string amount = "55000";
            string comments = "Base salary.";
            bool directDeposit = true;
            string accountNumber = "123456789";
            string accountType = "Other";
            string pleaseSpecify = "Student Loan";
            string routingNumber = "987654321";
            decimal amountDeposit = 5000.00m;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddSalary(EmployeeList.SelectEmployeeInTableById(), payGrade, salaryComponent, currency, amount,
                directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments);
            Assert.IsTrue(AssignedSalaryComponents.SalaryCorrectlyAdded(payGrade, salaryComponent, currency, amount, directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments), "Salary was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add a Salary for a Contractor")]
        public void AddContractorSalary()
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

            // Salary components
            #region
            string payGrade = "";
            string salaryComponent = "Base";
            string payFrequency = "Monthly";
            string currency = "United States Dollar";
            string amount = "65000";
            string comments = "Base salary.";
            bool directDeposit = true;
            string accountNumber = "123456789";
            string accountType = "Savings";
            string pleaseSpecify = "";
            string routingNumber = "987654321";
            decimal amountDeposit = 5000.00m;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();
            //AdminLandingPage.NavigateToEmployeeList();
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(firstName, middleName, lastName, createLoginDetails, userName, password, statusEnabled);

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddSalary(EmployeeList.SelectEmployeeInTableById(), payGrade, salaryComponent, currency, amount,
                           directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments);
            Assert.IsTrue(AssignedSalaryComponents.SalaryCorrectlyAdded(payGrade, salaryComponent, currency, amount, directDeposit, accountNumber, accountType, pleaseSpecify, routingNumber, amountDeposit, payFrequency, comments), "Salary was not added successfully.");

            Home.Logout();
        }

    }
}
