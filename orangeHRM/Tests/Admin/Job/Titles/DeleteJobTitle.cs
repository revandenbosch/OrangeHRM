using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class DeleteJobTitle : BaseTest
    {
        [Test]
        [Description("Delete a job title Admin - Job - Job Titles")]
        public void DeleteAJobTitle()
        {
            // Job title data
            #region
            string jobTitle = "Temporary Job Title";
            string jobDescription = "";
            string note = "This is a test job description.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create job title
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.AddJobTitle(jobTitle, jobDescription, note);

            // Delete the job title
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.DeleteJobTitle(jobTitle);

            Assert.IsTrue(JobTitles.JobTitleCorrectlyDeleted(jobTitle), $"The job title {jobTitle} was not correctly deleted.");

            Home.Logout();
        }
    }
}
