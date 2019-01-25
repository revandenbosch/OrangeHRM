using NUnit.Framework;
using OrangeHRM.PageObjects;
using System;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class VerifyDataImport : BaseTest
    {
        static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        static string projectPath = new Uri(actualPath).LocalPath;
        static string csvPath = projectPath + @"\DataFiles\";

        [Test]
        [Description("Verify PIM - Configuration - Data Import.")]
        public void VerifyAdminDashboardElements()
        {
            #region
            string employeeDataFile = "EmployeeData.csv";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.Configuration.DataImport.GoTo();

            CSVDataImport.ImportDataFile(csvPath + employeeDataFile);

            //Assert.IsTrue(CSVDataImport.IsLoadedCorrectly(csvPath + employeeDataFile), "The Employee CSVData Import not not load all records as expected!");
        }
    }
}
