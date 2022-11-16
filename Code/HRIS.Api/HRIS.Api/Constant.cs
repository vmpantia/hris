using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HRIS.Api
{
    public class Constant
    {
        public const string SQLConnectionConfiguration = "SqlConnectionString";

        public const string LogDirectory = @"D:\Logs\";
        public static string LogFileName = string.Concat("HRIS.Api", DateTime.Now.ToString("yyyyMMdd"), ".log");

        #region Stored Procedures
        public const string StoredProcedureGetEmployeeList = "sproc_GetEmployeeList";
        public const string StoredProcedureSaveEmployee_MST = "sproc_SaveEmployee_MST";
        public const string StoredProcedureSaveEmployee_TRN = "sproc_SaveEmployee_TRN";
        public const string StoredProcedureSaveRequest = "sproc_SaveRequest";
        #endregion

        #region Get Employee List Logs
        public const string LOG_Request_GetEmployeeList = "Get Employee List [ Filter By: {0}, Filter Value: {1}, From Date: {2}, To Date: {3}, Page No.: {4}, Page Size: {5} ]";
        public const string LOG_Success_GetEmployeeList = "Successfully Get Employee List [ No. of data retrieve: {0} ]";
        public const string LOG_Error_GetEmployeeList = "Error in Getting Employee List, Please check the Error Details: {0}";
        #endregion

        #region Post Save Employee Logs
        public const string LOG_Request_PostSaveEmployee = "Save Employee Record [ Employee Name: {0} ]";
        public const string LOG_Employee = "Employee";
        public const string LOG_Success_PostSaveEmployee = "Successfully Save Employee Record [ Employee ID: {0} ]";
        public const string LOG_Error_PostSaveEmployee = "Error in Saving Employee Record, Please check the Error Details: {0}";
        #endregion

        public const string LOG_CreateRequest = "Create {0} Request";
        public const string LOG_RequestDetails = "Request ID: {0}";

        public const string LOG_CreateTransaction = "Create {0} Transaction";
        public const string LOG_TransactionDetails = "Employee ID: {1}";

        public const string LOG_Saving = "Saving {0}";

        public const string NULL_Message = "The parameter can't be null";
        public const string PROBLEM_Message = "There's a problem in Saving Request, Transaction or Employee";

    }
}