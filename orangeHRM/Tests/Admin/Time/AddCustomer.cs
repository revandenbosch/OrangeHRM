using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddCustomer : BaseTest
    {
        [SetUp]
        [Description("If a FirstDayOfWeek has not been set all time menue functions do not exist.")]
        public void EnsureTimesheetPeriodDefined()
        {
            string firstDayOfWeek = "Monday";
 
            Home.LoginAsAdmin();
            
            Menu.Time.GoTo();

            // Test to see if FirstDayOfWeek exists, if it does set it to Monday
            if (Time.DefineTimesheetPeriod.IsDefineTimesheetPeriodDisplayed() == true)
            {
                Time.SetFirstDayOfWeek(firstDayOfWeek);
            }

            Home.Logout();
        }

        [Test]
        [Description("Create a new Customer")]
        public void CreateNewCustomer()
        {
            // Customer data
            #region
            string name = "Software Quality Unlimited";
            string description = "This is a test customer, please do not delete!";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Navigate To Customers
            Menu.Time.ProjectInfo.Customers.GoTo();
            Customers.AddNewCustomer(name, description);
            Assert.IsTrue(Customers.CustomerSuccessfullyAdded(name, description), "The Customer was not successfully added!");

            Home.Logout();
        }

        [Test]
        [Description("Try to create a duplicate Customer")]
        public void AdminCannotCreateDuplicateCustomer()
        {
            // Customer data
            #region
            string name = "Software Quality Unlimited";
            string description = "This is a test customer, please do not delete!";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Navigate To Customers
            Menu.Time.ProjectInfo.Customers.GoTo();
            // Add customer
            Customers.AddNewCustomer(name, description);

            // Navigate To Customers
            Menu.Time.ProjectInfo.Customers.GoTo();
            // Add same customer again
            Customers.AddNewCustomer(name, description);
            Assert.IsTrue(Customers.IsAlreadyExistsMsg(), "The Already Exists message was not successfully displayed!");

            //Customers.CancelBtn.Click();
            Home.Logout();
        }

        [Test]
        [Description("Delete a Customer")]
        public void DeleteCustomer()
        {
            // Customer data
            #region
            string name = "Software Quality Unlimited #2";
            string description = "This is a test customer. please do not delete!";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Navigate To Customers
            Menu.Time.ProjectInfo.Customers.GoTo();
            
            // Add customer
            Customers.AddNewCustomer(name, description);

            //Delete customer
            Customers.DeleteCustomer(name);
            Assert.IsTrue(Customers.CustomerSuccessfullyDeleted(name), "The Customer was not successfully deleted!");

            Home.Logout();
        }
    }
}
