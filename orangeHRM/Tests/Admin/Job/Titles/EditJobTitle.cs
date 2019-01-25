using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class EditJobTitle : BaseTest
    {
        [Test]
        [Description("Edit a job title, both title and description Admin - Job - Job Titles")]
        public void EditAJobTitle()
        {
            // Job title data
            #region
            string badJobTitle = "Quality Engineeeeering Manager";
            string badJobDescription = "Responsibleeeee for managing the SQA, QE, and QC groups.";
            string jobTitle = "Quality Engineering Manager";
            string jobDescription = "Responsible for managing the SQA, QE, and QC groups.";
            string note = "This is a test job description.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create job description with errors
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.AddJobTitle(badJobTitle, badJobDescription, note);

            // Edit the job title info with correct info
            JobTitles.EditJobTitle(badJobTitle, jobTitle, jobDescription, note);

            Assert.IsTrue(JobTitles.JobTitleCorrectlyAdded(jobTitle, jobDescription), $"The job title {jobTitle} was not correctly added.");

            // Cleanup
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.DeleteJobTitle(jobTitle);

            Home.Logout();
        }

        [Test]
        [Description("Edit a job title without optional Job Description Admin - Job - Job Titles")]
        public void EditAJobTitleWOJobDescription()
        {
            // Job title data
            #region
            string badJobTitle = "Quality Engineeeeer";
            string jobTitle = "Quality Engineer";
            string jobDescription = "";
            string note = "This is a test job description.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create job description with errors
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.AddJobTitle(badJobTitle, jobDescription, note);

            // Edit the job title info with correct info
            JobTitles.EditJobTitle(badJobTitle, jobTitle, jobDescription, note);

            Assert.IsTrue(JobTitles.JobTitleCorrectlyAdded(jobTitle, jobDescription), $"The job title {jobTitle} was not correctly added.");

            // Cleanup
            Menu.Admin.Job.JobTitles.GoTo();
            JobTitles.DeleteJobTitle(jobTitle);

            Home.Logout();
        }
    }
}
