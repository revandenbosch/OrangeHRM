using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{ 
    [TestFixture]
    public class EditEmployeeContactlDetails : BaseTest
    {
        [Test]
        [Description("Edit an EES user contact details by adding new data")]
        public void EditContactDetails()
        {
            // Employee data
            #region
            string eeName = "Test Ess";
            string addr1 = "1060 West Addison";
            string addr2 = "Unit 200A";
            string city = "Chicago";
            string state = "Illinois";
            string zip = "60613";
            string country = "United States";
            string homePhone = "773-388-8270";
            string mobilePhone = "773-380-2222";
            string workPhone = "773-388-8271";
            string workEmail = "testuser@baseball.com";
            string otherEmail = "testessuser@baseball.com";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.SearchForEmployee(eeName);
            Employee.EditContactDetails(EmployeeList.SelectEmployeeInTableById(), addr1: addr1, addr2: addr2, city: city, state: state, zip: zip, country: country,
            homePhone: homePhone, mobilePhone: mobilePhone, workPhone: workPhone, workEmail: workEmail, otherEmail: otherEmail);

            Assert.IsTrue(Employee.ContactCorrectlyAdded(addr1, addr2, city, state, zip, country, homePhone, mobilePhone, workPhone, workEmail, otherEmail), "Contact Details were not added successfully.");


            Home.Logout();
        }
    }
}
