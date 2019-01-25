using System;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace OrangeHRM.PageObjects
{
    public class CSVDataImport : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "btnSave")]
        [CacheLookup]
        public IWebElement UploadBtn { get; set; }

        [FindsBy(How = How.Id, Using = "pimCsvImport_csvFile")]
        [CacheLookup]
        public IWebElement ChooseFileBtn { get; set; }
        #endregion

        internal static void ImportDataFile(string employeeDataFile)
        {
            _logger.Info("Entering ImportDataFile().");

            try
            {
                Pages.CSVDataImport.ChooseFileBtn.SendKeys(employeeDataFile);

                Pages.CSVDataImport.UploadBtn.Click();
            }
            catch (Exception ex)
            {
                throw new Exception("Problem uploading Employee CSVData file: ", ex);
            }
            finally
            {
                _logger.Info("Exiting ImportDataFile().");
            }
           
        }

        internal static bool? IsLoadedCorrectly(string employeeDataFile)
        {
            _logger.Info("Entering IsLoadedCorrectly().");

            try
            {
                // Count number of emmployees in CSVData file
                long record_count = OrangeHRM.CountLinesInFile(employeeDataFile) - 1;

                // Get count from screen
                var screen_Text = Pages.CSVDataImport._driver.FindElement(By.XPath("//div[contains(@class, 'message success fadable')]")).Text;
               //var screen_Text  = Pages.CSVDataImport.NumberOfImportedRecords.Text;

               int num_Records_Imported = Int32.Parse(screen_Text.Remove(0, 28));

                if (record_count == num_Records_Imported)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
            finally
            {
                _logger.Info("Exiting IsLoadedCorrectly().");
            }
        }

    }
}