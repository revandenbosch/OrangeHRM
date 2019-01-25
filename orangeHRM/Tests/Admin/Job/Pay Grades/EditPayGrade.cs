using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class EditPayGrade : BaseTest
    {
        [Test]
        [Description("Edit a pay grade Admin - Job - Pay Grades")]
        public void EditAPayGrade()
        {
            // Pay grade data
            #region
            string payGrade = "Manger - Level2";
            string payGrade2 = "Manager - Level 2";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create a pay grade
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.AddPayGrade(payGrade);

            // Edit a pay grade
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.EditPayGrade(payGrade, payGrade2);

            Menu.Admin.Job.PayGrades.GoTo();
            Assert.IsTrue(PayGrade.PayGradeCorrectlyAssigned(payGrade2), $"The Pay Grade {payGrade2} was not correctly edited.");

            // Cleanup
            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.DeletePayGrade(payGrade);

            Home.Logout();
        }
    }
}
