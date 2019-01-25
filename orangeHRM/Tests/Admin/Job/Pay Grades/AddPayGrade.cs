using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddPayGrade : BaseTest
    {
        [Test]
        [Description("Add a pay grade Admin - Job - Pay Grades")]
        public void AddAPayGrade()
        {
            // Pay grade data
            #region
            string payGrade = "Manager - Level 1";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.AddPayGrade(payGrade);

            Assert.IsTrue(PayGrade.PayGradeCorrectlyAssigned(payGrade), $"The Pay Grade {payGrade} was not correctly added.");

            // Cleanup
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.DeletePayGrade(payGrade);

            Home.Logout();
        }
    }
}
