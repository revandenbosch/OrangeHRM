using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddCurrency : BaseTest
    {
        [Test]
        [Description("Add a pay grade Admin - Job - Pay Grades")]
        public void AddCurrencyToAPayGrade()
        {
            // Pay grade data
            #region
            string payGrade = "Manager - Level 2";
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

            Assert.IsTrue(PayGrade.AssignedCurrencies.CurrencyCorrectlyAssigned(payGrade, currency, minSalary, maxSalary), 
               $"The Currency {currency} with parameters Minimum Salary {minSalary} and Maximum Salary {maxSalary} was not added correctly to Pay Grade {payGrade}.");

            // Cleanup
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.DeletePayGrade(payGrade);

            Home.Logout();
        }
    }
}
