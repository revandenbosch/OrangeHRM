using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class DeleteOrganization : BaseTest
    {
        [Test]
        [Description("Add a Unit to the Organizational structure with a Unit ID")]
        public void DeleteAnOrganizationalUnitWithUnitID()
        {
            // Pay grade data
            #region
            string parentOrganization = "OrangeHRM (Pvt) Ltd";
            string name = "Quality Engineering";
            string unitId = "QE";
            string description = "The is the Quality Engineer group.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Organization.Structure.GoTo();
            OrganizationStructure.DeleteOrganizationalUnit(parentOrganization,  name, unitId);

            Assert.IsTrue(OrganizationStructure.OrganizationalUnitCorrectlyDeleted(parentOrganization, unitId, name), $"The Organizational Unit {unitId} was not correctly added.");

            // Cleanup
            Menu.Admin.Organization.Structure.GoTo();
            OrganizationStructure.DeleteOrganizationalUnit(parentOrganization, name, unitId);

            Home.Logout();
        }
        [Test]
        [Description("Create a multi-level Unit Organizational structure with a Unit ID's")]
        public void AddAMultiLevelnOrganizationalUnitWithUnitID()
        {
            
        }
    }
}
