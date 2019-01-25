using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class DeletePayGrade : BaseTest
    {
        [Test]
        [Description("Delete a pay grade Admin - Job - Pay Grades")]
        public void DeleteAPayGrade()
        {
            // Pay grade data
            #region
            string payGrade = "Manager - Level 2";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.AddPayGrade(payGrade);

            Menu.Admin.Job.PayGrades.GoTo();
            PayGrade.DeletePayGrade(payGrade);

           Assert.IsTrue(PayGrade.PayGradeCorrectlyDeleted(payGrade), $"The Pay Grade {payGrade} was not correctly deleted.");

            Home.Logout();
        }
    }
}
