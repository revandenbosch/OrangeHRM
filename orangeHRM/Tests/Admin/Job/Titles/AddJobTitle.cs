using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddJobTitle : BaseTest
    {
        [Test]
        [Description("Add a job title Admin - Job - Job Titles")]
        public void AddAJobTitle()
        {
            // Job title data
            #region
            string jobTitle = "Quality Engineering Manager";
            string jobDescription = "Responsible for managing the SQA, QE, and QC groups.";
            string note = "This is a test job description.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.AddJobTitle(jobTitle, jobDescription, note);

            Assert.IsTrue(JobTitles.JobTitleCorrectlyAdded(jobTitle, jobDescription), $"The job title {jobTitle} was not correctly added.");

            // Cleanup
            JobTitles.DeleteJobTitle(jobTitle);

            Home.Logout();
        }

        [Test]
        [Description("Add a job title without optional Job Description Admin - Job - Job Titles")]
        public void AddAJobTitleWOJobDescription()
        {
            // Job title data
            #region
            string jobTitle = "Quality Engineer";
            string jobDescription = "";
            string note = "This is a test job description.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.AddJobTitle(jobTitle, jobDescription, note);

            Assert.IsTrue(JobTitles.JobTitleCorrectlyAdded(jobTitle, jobDescription), $"The job title {jobTitle} was not correctly added.");

            // Cleanup
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.DeleteJobTitle(jobTitle);

            Home.Logout();
        }
    }
}
