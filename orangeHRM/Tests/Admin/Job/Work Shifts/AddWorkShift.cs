using NUnit.Framework;
using OrangeHRM.PageObjects;
using System;

namespace OrangeHRM.Tests
{
    [TestFixture]
    public class AddWorkShift : BaseTest
    {
        // Employee data
        #region
        private string _firstName1 = "Robert";
        private string _middleName1 = "David";
        private string _lastName1 = "Smith";

        private string _firstName2 = "John";
        private string _middleName2 = "W";
        private string _lastName2 = "Carson";

        private bool _createLoginDetails = false;

        #endregion

        [Test]
        [Description("Add a work shift Admin - Job - Work Shifts - No Employee Assigned")]
        public void AddWorkShiftNoEmployeeAssigned()
        {

            // Work shift data
            #region
            string shiftName = "Work Shift 1";
            string from = "08:00";
            string to = "12:00";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Create a work shift
            Menu.Admin.Job.WorkShifts.GoTo();
            WorkShifts.AddWorkShift(shiftName, from, to);

            Menu.Admin.Job.WorkShifts.GoTo();
            Assert.IsTrue(WorkShifts.WorkShiftCorrectlyAdded(shiftName, from, to), $"The work shift {shiftName} was not correctly added.");

            //Cleanup
            Menu.Admin.Job.WorkShifts.GoTo();
            WorkShifts.DeleteWorkShift(shiftName);

            Home.Logout();
        }

        [Test]
        [Description("Add a work shift Admin - Job - Work Shifts - Employees Assigned")]
        public void AddWorkShiftEmployeesAssigned()
        {

            // Work shift data
            #region
            string shiftName = "Work Shift 2";
            string from = "08:00";
            string to = "12:00";
            #endregion

            Home.GoTo();
            Home.LoginAsAdmin();

            // Add employees
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(_firstName1, _middleName1, _lastName1, _createLoginDetails);
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.AddEmployeeViaButton(_firstName2, _middleName2, _lastName2, _createLoginDetails);

            // Create a work shift and assign employees to work it
            Menu.Admin.Job.WorkShifts.GoTo();
            WorkShifts.AddWorkShift(shiftName, from, to);

            // Assign employees - the list takes first + middle + last
            string employee1 = _firstName1 + " " + _middleName1 + " " + _lastName1;
            string employee2 = _firstName2 + " " + _middleName2 + " " + _lastName2;

            string[] employees = { employee1, employee2 };
            WorkShifts.AssignEmployeeToWorkShift(shiftName, employees);

            Assert.IsTrue(WorkShifts.WorkShiftEmployeesCorrectlyAdded(shiftName, employees), $"The employees were not correctly added.");

            /// Cleanup
            Menu.PIM.EmployeeList.GoTo();
            EmployeeList.DeleteEmployee(_firstName1, _middleName1, _lastName1);
            EmployeeList.DeleteEmployee(_firstName2, _middleName2, _lastName2);
            Menu.Admin.Job.WorkShifts.GoTo();
            WorkShifts.DeleteWorkShift(shiftName);

            Home.Logout();
        }
    }
}
