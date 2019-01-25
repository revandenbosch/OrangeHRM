using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;


namespace AutomationFramework
{
    public class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                //if (_driver == null)
                //    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return _driver;
            }
            private set
            {
                _driver = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var resourcesDirectory = Path.GetFullPath(Path.Combine(outPutDirectory, @".\Drivers"));

            switch (browserName)
            {
                case "Edge":
                    if (Driver == null)
                    {
                        _driver = new EdgeDriver();
                        Drivers.Add("Edge", Driver);   
                    }

                    break;

                case "FireFox":
                    if (Driver == null)
                    {
                        _driver = new FirefoxDriver(resourcesDirectory);
                        Drivers.Add("FireFox", Driver);  
                    }
                    _driver = new FirefoxDriver(resourcesDirectory);
                    Drivers.Add("FireFox", Driver);
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        _driver = new InternetExplorerDriver(resourcesDirectory);
                        Drivers.Add("IE", Driver); 
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        _driver = new ChromeDriver(resourcesDirectory);
                        Drivers.Add("Chrome", Driver);   
                    }
                    break;
                case "Headless":
                    if (Driver == null)
                    {
                        ChromeOptions headlessOptions = new ChromeOptions();
                        headlessOptions.AddArgument("--headless");
                        _driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(resourcesDirectory), headlessOptions);
                        Drivers.Add("Chrome", Driver);                       
                    }
                    break;
                default:
                    {
                        if (Driver == null)
                        {
                            _driver = new ChromeDriver(resourcesDirectory);
                            Drivers.Add("Chrome", Driver);
                        }
                    }
                    break;
            }
        }

        public static void LoadApplication()
        {
            Driver.Url = ConfigurationManager.AppSettings["baseURL"];
        }

         public static void CloseAllDrivers()
        {
            
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit(); 
            }
            // Had to add cleanup so tests can be run more than one at a time
            // and to allow for running everything from a BaseTest.cs
            // TODO: Bulletproof the above methods.

            Driver = null;
            Drivers.Clear();
        }
    }
}
