using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests.Menus
{
    /// <summary>
    /// Summary description for Roles
    /// </summary>
    [TestFixture]
    public class ValidateAdminMenuToScreensSelections : BaseTest
    {
        [Test]
        [Description("Verifies the System Users page is present.")]
        public void VerifyAdminUserManagementUsers()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "User Management", "Users");
            Menu.Admin.UserManagement.Users.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("System Users"), "The System Users page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Job Titles page is present.")]
        public void VerifyAdminJobJobTitles()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Job", "Job Titles");
            Menu.Admin.Job.JobTitles.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Job Title"), "The Job Title page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Pay Grades page is present.")]
        public void VerifyAdminJobPayGrades()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Job", "Pay Grades");
            Menu.Admin.Job.PayGrades.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Pay Grades"), "The Pay Grades page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Employment Status page is present.")]
        public void VerifyAdminJobEmploymentStatus()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Job", "Employment Status");
            Menu.Admin.Job.EmploymentStatus.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Employment Status"), "The Employment Status page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Job Categories page is present.")]
        public void VerifyAdminJobJobCategories()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Job", "Job Categories");
            Menu.Admin.Job.JobCategories.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Job Categories"), "The Job Categories page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Work Shifts page is present.")]
        public void VerifyAdminJobWorkShifts()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Job", "Work Shifts");
            Menu.Admin.Job.WorkShifts.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Work Shifts"), "The Work Shifts page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the General Information page is present.")]
        public void VerifyAdminOrganizationGeneralInformation()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Organization", "General Information");
            Menu.Admin.Organization.GeneralInformation.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("General Information"), "The General Information page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Locations page is present.")]
        public void VerifyAdminOrganizationLocations()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Organization", "Locations");
            Menu.Admin.Organization.Locations.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Locations"), "The Locations page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Structure page is present.")]
        public void VerifyAdminOrganizationStructure()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Organization", "Structure");
            Menu.Admin.Organization.Structure.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Structure"), "The Structure page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Skills page is present.")]
        public void VerifyAdminQualificationsSkills()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Qualifications", "Skills");
            Menu.Admin.Qualifications.Skills.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Skills"), "The Skills page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Education page is present.")]
        public void VerifyAdminQualificationsEducation()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Qualifications", "Education");
            Menu.Admin.Qualifications.Education.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Education"), "The Education page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Licenses page is present.")]
        public void VerifyAdminQualificationsLicenses()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Qualifications", "Licenses");
            Menu.Admin.Qualifications.Licenses.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Licenses"), "The Licenses page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Languages page is present.")]
        public void VerifyAdminQualificationsLanguages()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Qualifications", "Languages");
            Menu.Admin.Qualifications.Languages.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Languages"), "The Languages page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Memberships page is present.")]
        public void VerifyAdminQualificationsMemberships()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Qualifications", "Memberships");
            Menu.Admin.Qualifications.Memberships.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Memberships"), "The Memberships page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Nationalities page is present.")]
        public void VerifyAdminNationalities()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Nationalities");
            Menu.Admin.Nationalities.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Nationalities"), "The Nationalities page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Mail Configuration page is present.")]
        public void VerifyAdminConfigurationMailConfiguration()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Configuration", "Email Configuration");
            Menu.Admin.Configuration.EmailConfiguration.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Mail Configuration"), "The Mail Configuration page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Email Notification page is present.")]
        public void VerifyAdminConfigurationEmailSubscriptions()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Configuration", "Email Subscriptions");
            Menu.Admin.Configuration.EmailSubscriptions.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Email Notification"), "The Email Notification page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Localization page is present.")]
        public void VerifyAdminConfigurationLocalizations()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Configuration", "Localization");
            Menu.Admin.Configuration.Localization.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Localization"), "The Localization page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Module Configuration page is present.")]
        public void VerifyAdminConfigurationModules()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Configuration", "Modules");
            Menu.Admin.Configuration.Modules.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Module Configuration"), "The Module Configuration page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Provider List page is present.")]
        public void VerifyAdminConfigurationSocialMediaAuthentication()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Configuration", "Social Media Authentication");
            Menu.Admin.Configuration.SocialMediaAuthentication.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Provider List"), "The Provider List page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Add OAuth Client page is present.")]
        public void VerifyAdminConfigurationRegisterOAuthClient()
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            //Pages.Home.MouseHover_SubMenusClick("Admin", "Configuration", "Register OAuth Client");
            Menu.Admin.Configuration.RegisterOAthClient.GoTo();
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed("Add OAuth Client"), "The Add OAuth Client page was not displayed.");
            Home.Logout();
        }
    }
}
