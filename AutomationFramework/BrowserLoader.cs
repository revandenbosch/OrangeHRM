using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AutomationFramework
{
    public class BrowserLoader
    {
        static string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        static string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
        static string projectPath = new Uri(actualPath).LocalPath;
        static string excelPath = projectPath + @"\DataFiles\";


        public static IEnumerable<TestCaseData> Test(string browser)
        {
            {

                List<TestCaseData> testCaseDataList = new List<TestCaseData>(); // Enum.GetValues(typeof(BrowserType))>();

                if (testCaseDataList != null)
                    foreach (TestCaseData testCaseData in Enum.GetValues(typeof(BrowserType)))
                        yield return testCaseData;
            }
    
    }
 
    }
}
