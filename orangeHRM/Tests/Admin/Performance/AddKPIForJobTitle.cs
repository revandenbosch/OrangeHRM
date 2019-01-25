using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddKPIForJobTitle: BaseTest
    {
        [Test]
        [Description("Add a KPI for a sales managet and set Default Scale = Yes")]
        public void AddKPIsForSalesManager1()
        {
            // KPI data
            #region
            string jobTitle = "Sales Manager";
            string kPI = "Gross sales exceed $10 million.";
            int minRating = 0;
            int maxRating = 5;
            bool makeDefaultScale = true;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Performance.Configure.KPIS.GoTo();
            KeyPerformanceIndicator.AddKPI(jobTitle, kPI, minRating, maxRating, makeDefaultScale);

            Assert.IsTrue(KeyPerformanceIndicator.KPICorrectlyAdded(jobTitle, kPI, minRating, maxRating, makeDefaultScale), 
                $"The KPI: {kPI} for Job Title: {jobTitle} was not correctly added.");
        }
        [Test]
        [Description("Add a KPI for a sales managet and set Default Scale = No")]
        public void AddKPIsForSalesManager2()
        {
            // KPI data
            #region
            string jobTitle = "Sales Manager";
            string kPI = "Client retention exceeds 90%.";
            int minRating = 0;
            int maxRating = 5;
            bool makeDefaultScale = false;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Performance.Configure.KPIS.GoTo();
            KeyPerformanceIndicator.AddKPI(jobTitle, kPI, minRating, maxRating, makeDefaultScale);

            Assert.IsTrue(KeyPerformanceIndicator.KPICorrectlyAdded(jobTitle, kPI, minRating, maxRating, makeDefaultScale),
                $"The KPI: {kPI} for Job Title: {jobTitle} was not correctly added.");
        }
        [Test]
        [Description("Add a KPI for a sales managet and set Default Scale = No")]
        public void AddKPIsForSalesManager3()
        {
            // KPI data
            #region
            string jobTitle = "Sales Manager";
            string kPI = "New client aquisition exceeds 4 per month.";
            int minRating = 0;
            int maxRating = 5;
            bool makeDefaultScale = false;
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Performance.Configure.KPIS.GoTo();
            KeyPerformanceIndicator.AddKPI(jobTitle, kPI, minRating, maxRating, makeDefaultScale);

            Assert.IsTrue(KeyPerformanceIndicator.KPICorrectlyAdded(jobTitle, kPI, minRating, maxRating, makeDefaultScale),
                $"The KPI: {kPI} for Job Title: {jobTitle} was not correctly added.");
        }
    }
}
