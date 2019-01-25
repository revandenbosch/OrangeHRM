using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class EditCurrency : BaseTest
    {
        [Test]
        [Description("Edit a currecny assigned to a pay grade Admin - Job - Pay Grades")]
        public void AddCurrencyToAPayGrade()
        {
            // Pay grade data
            #region
            string payGrade = "Manager - Level 2";
            // Original data
            string currency = "USD - United States Dollar";
            decimal minSalary = 50000.00m;
            decimal maxSalary = 65000.00m;
            // New data
            string currency2 = "GBP - Pound Sterling";
            decimal minSalary2 = 30000.00m;
            decimal maxSalary2 = 45000.00m;
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
            PayGrade.AssignedCurrencies.EditAssignedCurrency(payGrade, currency, currency2, minSalary2, maxSalary2);

            Assert.IsTrue(PayGrade.AssignedCurrencies.CurrencyCorrectlyAssigned(payGrade, currency2, minSalary2, maxSalary2), 
               $"The Currency {currency2} with parameters Minimum Salary {minSalary2} and Maximum Salary {maxSalary2} was not added correctly to Pay Grade {payGrade}.");

            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.DeletePayGrade(payGrade);

            Home.Logout();
        }
    }
}
