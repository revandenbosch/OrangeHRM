using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Configuration;
using AutomationFramework;
using System.Threading;
//using FindsBy = SeleniumExtras.PageObjects.FindsByAttribute;
//using How = SeleniumExtras.PageObjects.How;
//using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.PageObjects
{
    public class Home
    {
        private IWebDriver _driver = BrowserFactory.Driver;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        //Page object definitions
        #region 
        [FindsBy(How = How.Id, Using = "txtUsername")]
        [CacheLookup]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "txtPassword")]
        [CacheLookup]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogin")]
        [CacheLookup]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "spanMessage")]
        [CacheLookup]
        public IWebElement WarningMsg { get; set; }

        [FindsBy(How = How.ClassName, Using = "panelTrigger")]
        [CacheLookup]
        public IWebElement Welcome { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/index.php/auth/logout']")]
        [CacheLookup]
        public IWebElement LogoutButton { get; set; }
        #endregion

        public static void GoTo()
        {

        }

        public static void Login(string userName, string password)
        {
            Pages.Home.UserName.SendKeys(userName);
            Pages.Home.Password.SendKeys(password);
            _logger.Info($"Attempt to login as {userName}/{password}");
            Pages.Home.LoginButton.Click();
        }

        public static void LoginAsAdmin()
        {
            Pages.Home.UserName.SendKeys(ConfigurationManager.AppSettings["adminUID"]);
            Pages.Home.Password.SendKeys(ConfigurationManager.AppSettings["adminPWD"]);
            _logger.Info($"Attempt to login as {ConfigurationManager.AppSettings["adminUID"]}");

            Pages.Home.LoginButton.Click();
        }

        public static void Logout()
        {
            _logger.Info("Clicking on Welcome drop-down.");
            WebDriverWait wait = new WebDriverWait(Pages.Home._driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.ClassName("panelTrigger"))).Click();
            //Pages.Home.Welcome.Click();

            _logger.Info("Clicking on the Logout button.");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[@href='/index.php/auth/logout']"))).Click();
            //Pages.Home.LogoutButton.Click();
        }

        public static bool ValidateWarningMessage(string msg)
        {
            _logger.Info("Checking to see if correct message was displayed.");
            return Pages.Home.WarningMsg.Text.Contains(msg);
        }
        
        public static bool? LoginIsSuccessfull()
        {
            _logger.Info("Test to see if login was successful");
            return Pages.Home.Welcome.Text.Contains("Welcome Admin");
        }
        /*
        public static void MouseHover_SubMenusClick(string primaryMenu, string subMenu = null, string subSubMenu = null)
        {
            //Doing a MouseHover  
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            _logger.Info($"Locating top level menu item: {primaryMenu}.");
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//b[contains(text(), '" + primaryMenu + "')]")));
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
            if ((subMenu == null) || (subMenu == "null"))
            {
                _logger.Info($"Clicking on top level menu item: {primaryMenu}. No submenues.");
                element.Click();
            }
            else
            {
                //Clicking the SubMenu on MouseHover   
                if ((subSubMenu == null) || (subSubMenu == "null"))
                {
                    _logger.Info($"Locating top level menu item: {primaryMenu} and sub-menu item: {subMenu}.");
                    var subMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), '" + subMenu + "')]")));
                    Actions action2 = new Actions(_driver);
                    action2.MoveToElement(subMenuElement).Build().Perform();
                    _logger.Info($"Clicking on top level menu item: {primaryMenu} and sub-menu item: {subMenu}.");
                    subMenuElement.Click();
                } //Clicking the SubSubMenu on MouseHover 
                else
                {
                    _logger.Info($"Locating top level menu item: {primaryMenu}, sub-menu item: {subMenu} and subsub-menu item: {subSubMenu}.");
                    var subMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(@id, 'menu_" + primaryMenu.ToLower() + "_" + subMenu.Replace(" ", "") + "')]")));
                    Actions action2 = new Actions(_driver);
                    action2.MoveToElement(subMenuElement).Perform();
                    //I had to write this try/catch because I could not come up with an xpath to 
                    // use this <a href="/index.php/performance/searchPerformancReview" id="menu_performance_searchPerformancReview">Manage Reviews</a>
                    try
                    {
                        var subSubMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@id = 'menu_performance_searchPerformancReview']")));
                        Actions action3 = new Actions(_driver);
                        action3.MoveToElement(subSubMenuElement).Perform();
                        _logger.Info($"Clicking on top level menu item: {primaryMenu}, sub-menu item: {subMenu} and subsub-menu item: {subSubMenu}. Specifically for Manage Reviews");
                        subSubMenuElement.Click();
                    }
                    catch
                    {
                        var subSubMenuElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(), '" + subSubMenu + "')]")));
                        Actions action3 = new Actions(_driver);
                        action3.MoveToElement(subSubMenuElement).Perform();
                        _logger.Info($"Clicking on top level menu item: {primaryMenu}, sub-menu item: {subMenu} and subsub-menu item: {subSubMenu}.");
                        subSubMenuElement.Click();
                    }

                }
            }
        }
        */
    }
}
