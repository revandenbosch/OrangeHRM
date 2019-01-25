using NUnit.Framework;
using OrangeHRM.PageObjects;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddOrganization : BaseTest
    {
        [Test]
        [Description("Add a Unit to the Organizational structure with a Unit ID")]
        public void AddAnOrganizationalUnitWithUnitID()
        {
            // Organizational structure data
            #region
            string parentOrganization = "OrangeHRM (Pvt) Ltd";
            string name = "Quality Engineering";
            string unitId = "QE";
            string description = "The is the Quality Engineer group.";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Organization.Structure.GoTo();
            OrganizationStructure.AddOrganizationalUnit(parentOrganization,  name, unitId, description);

            //TODO: Write assertion code
            //Assert.IsTrue(OrganizationStructure.OrganizationalUnitCorrectlyAdded(parentOrganization, unitId, name, description), $"The Organizational Unit {unitId} was not correctly added.");

            // Cleanup
            //Menu.Admin.Organization.Structure.GoTo();
            OrganizationStructure.DeleteOrganizationalUnit(parentOrganization, name, unitId);

            Home.Logout();
        }
        [Test]
        [Description("Create a multi-level Unit Organizational structure with a Unit ID's")]
        public void AddAMultiLevelnOrganizationalUnitWithUnitID()
        {
            // Organizational structure data
            #region
            string parentOrganization1 = "OrangeHRM (Pvt) Ltd";
            string name1 = "Regulatory Affairs";
            string unitId1 = "RA";
            string description1 = "The is the Regulatory Affairs department.";

            string parentOrganization2 = "RA : Regulatory Affairs";
            string name2 = "Quality Engineering";
            string unitId2 = "QE";
            string description2 = "The is the Quality Engineering group.";

            string parentOrganization3 = "RA : Regulatory Affairs";
            string name3 = "Quality Control";
            string unitId3 = "QC";
            string description3 = "The is the Quality Control group.";

            string parentOrganization4 = "QC : Quality Control";
            string name4 = "Documentation Control";
            string unitId4 = "DC";
            string description4 = "The is the Documentation Control group.";


            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            Menu.Admin.Organization.Structure.GoTo();
            // Add Org Unit 1
            OrganizationStructure.AddOrganizationalUnit(parentOrganization1, name1, unitId1, description1);

            // Add Org Unit 2
            OrganizationStructure.AddOrganizationalUnit(parentOrganization2, name2, unitId2, description2);

            // Add Org Unit 3
            OrganizationStructure.AddOrganizationalUnit(parentOrganization3, name3, unitId3, description3);

            // Add Org Unit 4
            OrganizationStructure.AddOrganizationalUnit(parentOrganization4, name4, unitId4, description4);

            //Assert.IsTrue(OrganizationStructure.OrganizationalUnitCorrectlyAdded(parentOrganization1, unitId1, name1, description1), $"The Organizational Unit {unitId1} was not correctly added.");

            // Cleanup
            OrganizationStructure.DeleteOrganizationalUnit(parentOrganization1, name1, unitId1);

            Home.Logout();
        }
    }
}
