using NUnit.Framework;
using AutomationFramework;
using OpenQA.Selenium;
using System.Threading;
using NUnit.Framework.Internal;

namespace OrangeHRM
{
    /// <summary>
    /// Summary description for BaseTest
    /// </summary>
    //[TestFixture, TestFixtureSource(typeof(BrowserType), "Browser Tests")]
    //[TestFixture("Chrome") ]
    public class BaseTest
    {
        [SetUp]
        //[TestCaseSource(typeof(BrowserLoader), nameof(Test), string browser)]
        public void SetupForEverySingleTestMethod()
        {
            BrowserFactory.InitBrowser("Chrome");
            //BrowserFactory.InitBrowser("FireFox");
            BrowserFactory.LoadApplication();
        }
        
        [TearDown]
        public void CleanUpAfterEveryTestMethod()
        {
            BrowserFactory.CloseAllDrivers();   
        }
        [OneTimeTearDown]
        public void CleanupDrivers()
        {
            //BrowserFactory.CloseAllDrivers();
        }
    }
}
