using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddImmigration : BaseTest
    {
        [Test]
        [Description("Add a Passort for Test Ess User")]
        public void AddPassportRecord()
        {
            string eeName = "Test Ess";

            // Immigration data
            #region
            string document = "Passport";
            string docNumber = "A17-B340098";
            string issueDate = "2010-04-06";
            string expiryDate = "2015-04-06";
            string eligibilityStatus = "Eligable";
            string issuedBy = "United States";
            string eligibilityReviewDate = "";
            string comments = "This is a US citizen.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddImmigration(EmployeeList.SelectEmployeeInTableById(), document, docNumber, issueDate, expiryDate, eligibilityStatus, issuedBy, eligibilityReviewDate, comments);
            Assert.IsTrue(Immigration.ImmigrationRecordCorrectlyAdded(document, docNumber, issueDate, expiryDate, eligibilityStatus, issuedBy, eligibilityReviewDate, comments), "Immigration document was not added successfully.");

            Home.Logout();
        }

        [Test]
        [Description("Add a Visa for Test Ess User")]
        public void AddVisaRecord()
        {
            string eeName = "Test Ess";

            // Immigration data
            #region
            string document = "Visa";
            string docNumber = "V13000-A0098";
            string issueDate = "2018-04-06";
            string expiryDate = "2023-04-06";
            string eligibilityStatus = "Ineligable";
            string issuedBy = "Ireland";
            string eligibilityReviewDate = "2022-11-06";
            string comments = "Looking for H1B sponsorship.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.AddImmigration(EmployeeList.SelectEmployeeInTableById(), document, docNumber, issueDate, expiryDate, eligibilityStatus, issuedBy, eligibilityReviewDate, comments);
            Assert.IsTrue(Immigration.ImmigrationRecordCorrectlyAdded(document, docNumber, issueDate, expiryDate, eligibilityStatus, issuedBy, eligibilityReviewDate, comments), "Immigration document was not added successfully.");

            Home.Logout();
        }

      
    }
}
