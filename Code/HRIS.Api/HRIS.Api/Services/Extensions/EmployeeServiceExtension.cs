using HRIS.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace HRIS.Api.Services.Extensions
{
    internal static class EmployeeServiceExtension
    {
        public static void EmployeeCommandParameters(this Employee inputEmployee, SqlCommand command, bool isMST)
        {
            inputEmployee.InternalID = inputEmployee.InternalID == Guid.Empty ? Guid.NewGuid() : inputEmployee.InternalID;
            SqlParameter[] parameter = new[]
            {
                new SqlParameter("@InternalID", SqlDbType.UniqueIdentifier) { Value = inputEmployee.InternalID },
                new SqlParameter("@FirstName", SqlDbType.VarChar, 20) { Value = inputEmployee.FirstName },
                new SqlParameter("@MiddleName", SqlDbType.VarChar, 20) { Value = inputEmployee.MiddleName },
                new SqlParameter("@LastName", SqlDbType.VarChar, 20) { Value = inputEmployee.LastName },
                new SqlParameter("@Gender", SqlDbType.VarChar, 10) { Value = inputEmployee.Gender },
                new SqlParameter("@BirthDate", SqlDbType.DateTime) { Value = inputEmployee.BirthDate },
                new SqlParameter("@CivilStatus", SqlDbType.VarChar, 10) { Value = inputEmployee.CivilStatus },
                new SqlParameter("@ContactList", SqlDbType.Structured) { Value = ContactListCommandParameters(inputEmployee.ContactList, inputEmployee.InternalID) },
                new SqlParameter("@AddressList", SqlDbType.Structured) { Value = AddressListCommandParameters(inputEmployee.AddressList, inputEmployee.InternalID) },
                new SqlParameter("@Status", SqlDbType.Int) { Value = inputEmployee.Status },
                new SqlParameter("@CreatedBy", SqlDbType.UniqueIdentifier) { Value = inputEmployee.CreatedBy  },
                new SqlParameter("@ModifiedBy", SqlDbType.UniqueIdentifier) { Value = inputEmployee.ModifiedBy ?? SqlGuid.Null },
                new SqlParameter("@CreatedDate", SqlDbType.DateTime) { Value = inputEmployee.CreatedDate },
                new SqlParameter("@ModifiedDate", SqlDbType.DateTime) { Value = inputEmployee.ModifiedDate ?? SqlDateTime.Null }
            };

            command.Parameters.AddRange(parameter);

            if (isMST)
            {
                command.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.VarChar, 15) { Value = inputEmployee.EmployeeID });
                return;
            }
            command.Parameters.Add(new SqlParameter("@RequestID", SqlDbType.VarChar, 15) { Value = inputEmployee.RequestID });
            command.Parameters.Add(new SqlParameter("@EmployeeID", SqlDbType.VarChar, 15) { Direction = ParameterDirection.Output });
        }

        private static List<SqlDataRecord> ContactListCommandParameters(List<Contact> contactList, Guid EmployeeInternalID)
        {
            List<SqlDataRecord> datatable = new List<SqlDataRecord>();
            if (contactList == null && contactList.Count < 0)
            {
                return null;
            }

            SqlMetaData[] sqlMetaData = new SqlMetaData[9];
            sqlMetaData[0] = new SqlMetaData("@InternalID", SqlDbType.UniqueIdentifier);
            sqlMetaData[1] = new SqlMetaData("@Employee_InternalID", SqlDbType.UniqueIdentifier);
            sqlMetaData[2] = new SqlMetaData("@PrimaryFlag", SqlDbType.Int);
            sqlMetaData[3] = new SqlMetaData("@Type", SqlDbType.Int);
            sqlMetaData[4] = new SqlMetaData("@Value", SqlDbType.VarChar, 50);
            sqlMetaData[5] = new SqlMetaData("@CreatedBy", SqlDbType.UniqueIdentifier);
            sqlMetaData[6] = new SqlMetaData("@ModifiedBy", SqlDbType.UniqueIdentifier);
            sqlMetaData[7] = new SqlMetaData("@CreatedDate", SqlDbType.DateTime);
            sqlMetaData[8] = new SqlMetaData("@ModifiedDate", SqlDbType.DateTime);
            foreach (var contact in contactList)
            {
                contact.InternalID = contact.InternalID == Guid.Empty ? Guid.NewGuid() : contact.InternalID;
                contact.Employee_InternalID = EmployeeInternalID;
                SqlDataRecord row = new SqlDataRecord(sqlMetaData);
                row.SetValues(new object[] { contact.InternalID,
                                             contact.Employee_InternalID,
                                             contact.PrimaryFlag, 
                                             contact.Type, 
                                             contact.Value, 
                                             contact.CreatedBy, 
                                             contact.ModifiedBy ?? SqlGuid.Null, 
                                             contact.CreatedDate, 
                                             contact.ModifiedDate ?? SqlDateTime.Null });
                datatable.Add(row);
            }
            return datatable;
        }

        private static List<SqlDataRecord> AddressListCommandParameters(List<Address> addressList, Guid EmployeeInternalID)
        {
            List<SqlDataRecord> datatable = new List<SqlDataRecord>();
            if (addressList == null && addressList.Count < 0)
            {
                return null;
            }

            SqlMetaData[] sqlMetaData = new SqlMetaData[13];
            sqlMetaData[0] = new SqlMetaData("@InternalID", SqlDbType.UniqueIdentifier);
            sqlMetaData[1] = new SqlMetaData("@Employee_InternalID", SqlDbType.UniqueIdentifier);
            sqlMetaData[2] = new SqlMetaData("@Type", SqlDbType.Int);
            sqlMetaData[3] = new SqlMetaData("@FirstLevel", SqlDbType.VarChar, 30);
            sqlMetaData[4] = new SqlMetaData("@SecondLevel", SqlDbType.VarChar, 30);
            sqlMetaData[5] = new SqlMetaData("@Barangay", SqlDbType.VarChar, 30);
            sqlMetaData[6] = new SqlMetaData("@City", SqlDbType.VarChar, 30);
            sqlMetaData[7] = new SqlMetaData("@Province", SqlDbType.VarChar, 30);
            sqlMetaData[8] = new SqlMetaData("@Country", SqlDbType.VarChar, 30);
            sqlMetaData[9] = new SqlMetaData("@CreatedBy", SqlDbType.UniqueIdentifier);
            sqlMetaData[10] = new SqlMetaData("@ModifiedBy", SqlDbType.UniqueIdentifier);
            sqlMetaData[11] = new SqlMetaData("@CreatedDate", SqlDbType.DateTime);
            sqlMetaData[12] = new SqlMetaData("@ModifiedDate", SqlDbType.DateTime);
            foreach (var address in addressList)
            {
                address.InternalID = address.InternalID == Guid.Empty ? Guid.NewGuid() : address.InternalID;
                address.Employee_InternalID = EmployeeInternalID;
                SqlDataRecord row = new SqlDataRecord(sqlMetaData);
                row.SetValues(new object[] { address.InternalID,
                                             address.Employee_InternalID,
                                             address.Type,
                                             address.FirstLevel,
                                             address.SecondLevel,
                                             address.Barangay,
                                             address.City,
                                             address.Province,
                                             address.Country,
                                             address.CreatedBy,
                                             address.ModifiedBy ?? SqlGuid.Null,
                                             address.CreatedDate,
                                             address.ModifiedDate ?? SqlDateTime.Null });
                datatable.Add(row);
            }
            return datatable;
        }
    }
}