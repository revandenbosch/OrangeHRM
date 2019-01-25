using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class DeleteCurrency : BaseTest
    {
        [Test]
        [Description("Edit a currecny assigned to a pay grade Admin - Job - Pay Grades")]
        public void DeleteCurrencyAssignedToAPayGrade()
        {
            // Pay grade data
            #region
            string payGrade = "Manager - Level 3";
            // Original data
            string currency = "USD - United States Dollar";
            decimal minSalary = 50000.00m;
            decimal maxSalary = 65000.00m;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Job.PayGrades.GoTo();

            // Create a new pay grade
            PayGrade.AddPayGrade(payGrade);

            // Assign a currency to a pay grade
            PayGrade.AssignedCurrencies.AssignCurrency(payGrade, currency, minSalary, maxSalary);

            // Edit a currency assigned to a pay grade
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.AssignedCurrencies.DeleteAssignedCurrency(payGrade, currency);

            Assert.IsTrue(PayGrade.AssignedCurrencies.CurrencyCorrectlyDeleted(payGrade, currency), $"The Currency {currency} was not deleted correctly from Pay Grade {payGrade}.");

            //Cleanup
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.DeletePayGrade(payGrade);

            Home.Logout();
        }
    }
}
