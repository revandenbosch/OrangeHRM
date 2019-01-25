using SeleniumExtras.PageObjects;
using AutomationFramework;

//using OpenQA.Selenium.Support.PageObjects;

namespace OrangeHRM.PageObjects
{
    public static class Pages
    {
        //public static IWebDriver _driver;

        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static OrangeHRM OrangeHRM => GetPage<OrangeHRM>();

        public static Home Home => GetPage<Home>();

        public static Menu Menu => GetPage<Menu>();

        public static EssLanding EssLanding => GetPage<EssLanding>();

        public static AdminLanding AdminLanding => GetPage<AdminLanding>();

        public static Dashboard Dashboard => GetPage<Dashboard>();

        public static EmployeeList EmployeeList => GetPage<EmployeeList>();

        public static Employee Employee => GetPage<Employee>();

        public static AddEmployee AddEmployee => GetPage<AddEmployee>();

        public static ContactDetails ContactDetails => GetPage<ContactDetails>();

        public static AssignEmergencyContacts AssignEmergencyContacts => GetPage<AssignEmergencyContacts>();

        public static Job Job => GetPage<Job>();

        public static AssignedSalaryComponents AssignedSalaryComponents => GetPage<AssignedSalaryComponents>();

        public static PersonalDetails PersonalDetails => GetPage<PersonalDetails>();

        public static AssignDependent AssignDependent => GetPage<AssignDependent>();

        public static TerminateEmploymentDialog TerminateEmployment => GetPage<TerminateEmploymentDialog>();

        public static Immigration Immigration => GetPage<Immigration>();

        public static Time Time => GetPage<Time>();

        public static Customers Customers => GetPage<Customers>();

        public static Dialog Dialog => GetPage<Dialog>();

        public static JobTitles JobTitles => GetPage<JobTitles>();

        public static PayGrade PayGrade => GetPage<PayGrade>();

        public static KeyPerformanceIndicator KeyPerformanceIndicator => GetPage<KeyPerformanceIndicator>();

        public static CSVDataImport CSVDataImport => GetPage<CSVDataImport>();

        public static WorkShifts WorkShifts => GetPage<WorkShifts>();

        public static OrganizationStructure OrganizationStructure => GetPage<OrganizationStructure>();

        public static Projects Projects  => GetPage<Projects>();

    }
}
