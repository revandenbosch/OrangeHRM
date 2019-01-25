using AutomationFramework;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests.Menus
{
    [TestFixture]
    public class AdvancedValidateMenuToScreensSelections : BaseTest
    {
        private const string dataFile = "MenuToScreenMappings.xlsx";
        private const string tab1 = "Admin";
        private const string tab2 = "PIM";
        private const string tab3 = "Leave";
        private const string tab4 = "Time";
        private const string tab5 = "Recruitment";
        private const string tab6 = "Performance";
        private const string tab7 = "Dashboard";
        private const string tab8 = "Directory" ;
 
        [Test]
        [Description("Verifies the Admin Menus to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab1 })]
        public void VerifyAdminMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the PIM Menus to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab2 })]
        public void VerifyPIMMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            //Pages.Home.NavigateMenues(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Leave Menus to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab3 })]
        public void VerifyLeaveMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Time Menu to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab4 })]
        public void VerifyTimeMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Recruitment Menus to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab5 })]
        public void VerifyRecruitmentMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Performance Menus to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab6 })]
        public void VerifyPerformanceMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Dashboard Menu to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab7 })]
        public void VerifyDashboardMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }

        [Test]
        [Description("Verifies the Driectory Menu to screen mappings.")]
        [TestCaseSource(typeof(ExcelDataParser), nameof(Test), new object[] { dataFile, tab8 })]
        public void VerifyDirectoryMenuToScreenMapping(string primaryMenu, string subMenu, string subSubMenu, string screenTitle)
        {
            Home.GoTo();
            Home.LoginAsAdmin();
            Pages.Menu.MouseHover_SubMenusClick(primaryMenu, subMenu, subSubMenu);
            Assert.IsTrue(Pages.Menu.IsCorrectPageDispayed(screenTitle), $"The {screenTitle} page was not displayed.");
            Home.Logout();
        }
    }
}
