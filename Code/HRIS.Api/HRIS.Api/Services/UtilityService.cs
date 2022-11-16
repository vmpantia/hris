using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using HRIS.Model;
using HRIS.Logger;

namespace HRIS.Api.Services
{
    public class UtilityService : IUtilityService
    {
        public ILoggerManager GetLoggerManager()
        {
            ILoggerManager logger = new LoggerManager(Constant.LogFileName, Constant.LogDirectory);
            return logger;
        }

        public string SQLConnectiongString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[Constant.SQLConnectionConfiguration].ConnectionString;
            }
        }

        public Employee ParseEmployee(DataRow dataRow)
        {
            int idx = 0;
            return new Employee
            {
                InternalID = Guid.Parse(dataRow[idx].ToString()),
                EmployeeID = dataRow[++idx].ToString(),
                FirstName = dataRow[++idx].ToString(),
                LastName = dataRow[++idx].ToString(),
                MiddleName = dataRow[++idx].ToString(),
                Suffix = dataRow[++idx].ToString(),
                Gender = dataRow[++idx].ToString(),
                BirthDate = DateTime.Parse(dataRow[++idx].ToString()),
                PlaceOfBirth = dataRow[++idx].ToString(),
                Nationality = dataRow[++idx].ToString(),
                Religion = dataRow[++idx].ToString(),
                CivilStatus = dataRow[++idx].ToString(),
                M_FirstName = dataRow[++idx].ToString(),
                M_LastName = dataRow[++idx].ToString(),
                M_MiddleName = dataRow[++idx].ToString(),
                M_Suffix = dataRow[++idx].ToString(),
                M_BirthDate = DateTime.Parse(dataRow[++idx].ToString()),
                M_ContactNo = dataRow[++idx].ToString(),
                F_FirstName = dataRow[++idx].ToString(),
                F_LastName = dataRow[++idx].ToString(),
                F_MiddleName = dataRow[++idx].ToString(),
                F_Suffix = dataRow[++idx].ToString(),
                F_BirthDate = DateTime.Parse(dataRow[++idx].ToString()),
                F_ContactNo = dataRow[++idx].ToString(),
                Status = int.Parse(dataRow[++idx].ToString()),
                CreatedBy = Guid.Parse(dataRow[++idx].ToString()),
                ModifiedBy = Guid.Parse(dataRow[++idx].ToString() ?? null),
                CreatedDate = DateTime.Parse(dataRow[++idx].ToString()),
                ModifiedDate = DateTime.Parse(dataRow[++idx].ToString())
            };
        }
    }
}