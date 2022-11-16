using System;
using System.Collections.Generic;
using HRIS.Api.Services;
using HRIS.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HRIS.Api.Test
{
    [TestClass]
    public class EmployeeServiceTest
    {
        [TestMethod]
        public void PostSaveEmployeeTest_001()
        {
            //Arrange
            IUtilityService utility = new UtilityService();
            ICommonService common = new CommonService();
            var employeeService = new EmployeeService(common, utility);

            var inputEmployee = new Employee
            {
                InternalID = Guid.Empty,
                EmployeeID = string.Empty,
                FirstName = "VINCENT",
                MiddleName = "MARINO",
                LastName = "PANTIA",
                Gender = "MALE",
                BirthDate = DateTime.Today,
                CivilStatus = "SINGLE",
                ContactList = new List<Contact>
                {
                    new Contact
                    {
                        InternalID = Guid.Empty,
                        Employee_InternalID = Guid.Empty,
                        PrimaryFlag = 0,
                        Type = 0,
                        Value = "09090957142",
                        CreatedBy = Guid.Empty,
                        ModifiedBy = null,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = null
                    }
                },

                AddressList = new List<Address>
                {
                    new Address
                    {
                        InternalID = Guid.Empty,
                        Employee_InternalID = Guid.Empty,
                        Type = 0,
                        FirstLevel = "TEST",
                        SecondLevel = "TEST",
                        Barangay = "Pasong Tamo",
                        City = "Quezon City",
                        Province = "Metro Manila",
                        Country = "Philippines",
                        CreatedBy = Guid.Empty,
                        ModifiedBy = null,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = null
                    }
                },
                Status = 0,
                CreatedBy = Guid.Empty,
                ModifiedBy = null,
                CreatedDate = DateTime.Today,
                ModifiedDate = null,

                RequestID = string.Empty,
                FunctionID = "TEST",
                RequestStatus = 0,
                RequestBy = null,
                RequestDate = DateTime.Today,
                ApprovedBy = null,
                ApprovedDate = null,
                CompletedDate = DateTime.Today,
                LastModifiedDate = null
            };

            var actual = employeeService.PostSaveEmployee(inputEmployee);

            Assert.IsFalse(string.IsNullOrEmpty(actual.EmployeeID));
            Assert.IsFalse(string.IsNullOrEmpty(actual.RequestID));
        }

        [TestMethod]
        public void PostSaveEmployeeTest_002()
        {
            //Arrange
            IUtilityService utility = new UtilityService();
            ICommonService common = new CommonService();
            var employeeService = new EmployeeService(common, utility);

            var inputEmployee = new Employee
            {
                InternalID = Guid.Empty,
                EmployeeID = string.Empty,
                FirstName = "TEST2",
                MiddleName = "TEST2",
                LastName = "TEST2",
                Gender = "MALE",
                BirthDate = DateTime.Today,
                CivilStatus = "SINGLE",
                ContactList = new List<Contact>
                {
                    new Contact
                    {
                        InternalID = Guid.Empty,
                        Employee_InternalID = Guid.Empty,
                        PrimaryFlag = 0,
                        Type = 0,
                        Value = "09090957142",
                        CreatedBy = Guid.Empty,
                        ModifiedBy = null,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = null
                    }
                },

                AddressList = new List<Address>
                {
                    new Address
                    {
                        InternalID = Guid.Empty,
                        Employee_InternalID = Guid.Empty,
                        Type = 0,
                        FirstLevel = "TEST",
                        SecondLevel = "TEST",
                        Barangay = "Pasong Tamo",
                        City = "Quezon City",
                        Province = "Metro Manila",
                        Country = "Philippines",
                        CreatedBy = Guid.Empty,
                        ModifiedBy = null,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = null
                    }
                },
                Status = 0,
                CreatedBy = Guid.Empty,
                ModifiedBy = null,
                CreatedDate = DateTime.Today,
                ModifiedDate = null,

                RequestID = string.Empty,
                FunctionID = "TEST",
                RequestStatus = 1,
                RequestBy = null,
                RequestDate = DateTime.Today,
                ApprovedBy = null,
                ApprovedDate = null,
                CompletedDate = DateTime.Today,
                LastModifiedDate = null
            };

            var actual = employeeService.PostSaveEmployee(inputEmployee);

            Assert.IsFalse(string.IsNullOrEmpty(actual.EmployeeID));
            Assert.IsFalse(string.IsNullOrEmpty(actual.RequestID));
        }
    }
}
