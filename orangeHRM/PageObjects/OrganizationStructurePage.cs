using System;
using System.Collections.Generic;
using System.Threading;
using AutomationFramework;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class OrganizationStructure : OrangeHRM
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        // Page object definitions
        #region
        [FindsBy(How = How.Id, Using = "btnEdit")]
        [CacheLookup]
        public IWebElement EditBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='addButton']")]
        [CacheLookup]
        public IWebElement AddChild { get; set; }

        //[FindsBy(How = How.XPath, Using = "//a[@class='deleteButton']")]
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@id, 'treeLink_delete_')]")]
        [CacheLookup]
        public IWebElement DeleteChild { get; set; }

        [FindsBy(How = How.Id, Using = "txtUnit_Id")]
        [CacheLookup]
        public IWebElement UnitID { get; set; }

        [FindsBy(How = How.Id, Using = "txtName")]
        [CacheLookup]
        public IWebElement Name { get; set; }

        [FindsBy(How = How.Id, Using = "txtDescription")]
        [CacheLookup]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.Id, Using = "lblParentNotice")]
        [CacheLookup]
        public IWebElement Parent { get; set; }

        [FindsBy(How = How.Id, Using = "btnEdit")]
        [CacheLookup]
        public IWebElement DoneBtn { get; set; }

        #endregion


        internal static void AddOrganizationalUnit(string parentOrganization,  string name, string unitId = "",  string description = "")
        {
            _logger.Info("Entering AddOrganizationalUnit()");

            try
            {
                int index = 0;

                Pages.OrganizationStructure.EditBtn.Click();

                IReadOnlyCollection<IWebElement> spans =  Pages.OrganizationStructure._driver.FindElements(By.XPath("//*/a[starts-with(@class, 'editLink')]"));
                foreach (IWebElement span in spans)
                {
                    if (span.GetAttribute("text") == parentOrganization)
                    {
                        // Add the organizational unit
                        IList<IWebElement> addButton = span.FindElements(By.XPath("//a[starts-with(@id, 'treeLink_addChild_')]"));
                        addButton[index].Click();

                        Pages.OrganizationStructure.UnitID.Clear();
                        Pages.OrganizationStructure.UnitID.SendKeys(unitId);
                        Pages.OrganizationStructure.Name.Clear();
                        Pages.OrganizationStructure.Name.SendKeys(name);
                        Pages.OrganizationStructure.Description.Clear();
                        Pages.OrganizationStructure.Description.SendKeys(description);
                        Pages.OrganizationStructure.SaveBtn.Click();
                        //Thread.Sleep(3);
                        Pages.OrganizationStructure.DoneBtn.Click();
                        break;
                    }
                    index = index + 1;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"A problem was encountered adding a child Organizational Unit to {parentOrganization}: {ex}");
            }
            finally
            {
                _logger.Info("Exiting AddOrganizationalUnit()");
            }
        }


        internal static void DeleteOrganizationalUnit(string parentOrganization, string name, string unitId)
        {
            _logger.Info("Entering DeleteOrganizationalUnit()");

            try
            {
                string orgFullName = unitId + " : " + name;

                int index = 0;

                //locate root node
                IList<IWebElement> spans = Pages.OrganizationStructure._driver.FindElements(By.XPath("//*/a[starts-with(@id, 'treeLink_edit')]"));
                foreach (IWebElement span in spans)
                {                   
                    if (span.GetAttribute("text") == orgFullName)
                    {
                        // Enable tree for editing
                        Pages.OrganizationStructure.EditBtn.Click();

                        // Delete the organizational unit
                        IList<IWebElement> deleteButton = span.FindElements(By.XPath("//*/a[starts-with(@id, 'treeLink_delete_')]"));
                        Thread.Sleep(10);
                        deleteButton[index-1].Click();
                        Thread.Sleep(10);

                        WebDriverWait wait = new WebDriverWait(Pages.OrganizationStructure._driver, TimeSpan.FromSeconds(15));
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("dialogYes"))).Click();
                        //Pages.Dialog.OkBtn.Click();

                        //Pages.OrganizationStructure.DoneBtn.Click();
                        Thread.Sleep(15);
                        break;
                    }

                    index = index + 1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"A problem was encountered trying to delete Organizational Unit to {parentOrganization}: {ex}");
            }
            finally
            {
                _logger.Info("Exiting DeleteOrganizationalUnit()");
            }
        }

        internal static bool? OrganizationalUnitCorrectlyDeleted(string parentOrganization, string unitId, string name)
        {
            throw new NotImplementedException();
        }


        internal static bool? OrganizationalUnitCorrectlyAdded(string parentOrganization, string unitId, string name, string description)
        {
            throw new NotImplementedException();
        }

    }
}