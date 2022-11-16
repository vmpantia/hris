using HRIS.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using HRIS.Logger;
using HRIS.Api.Services.Extensions;

namespace HRIS.Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        ICommonService _common;
        IUtilityService _utility;
        ILoggerManager _logger;
        public EmployeeService(ICommonService common, IUtilityService utility)
        { 
            _logger = utility.GetLoggerManager();
            _common = common;
            _utility = utility;
        }

        public List<Employee> GetEmployeeList(FilterSetting filterSetting)
        {
            if(filterSetting == null)
            {
                _logger.LogError(string.Format(Constant.LOG_Error_GetEmployeeList, Constant.NULL_Message));
                return null;
            }

            _logger.LogInfo(string.Format(Constant.LOG_Request_GetEmployeeList, 
                                          filterSetting.FilterBy, 
                                          filterSetting.FilterValue, 
                                          filterSetting.FilterFromDate, 
                                          filterSetting.FilterToDate, 
                                          filterSetting.PageNo, 
                                          filterSetting.PageSize));

            var result = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(_utility.SQLConnectiongString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction();
                try
                {
                    var dataSet = new DataSet();
                    using (var command = transaction.Connection.CreateCommand())
                    {
                        command.Transaction = transaction;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = Constant.StoredProcedureGetEmployeeList;
                        filterSetting.FilterCommandParameters(command);
                        var dataAdapter = new SqlDataAdapter(command);
                        dataAdapter.Fill(dataSet);
                    }
                    var table = dataSet?.Tables?[0];
                    foreach (DataRow row in table.Rows)
                    {
                        result.Add(_utility.ParseEmployee(row));
                    }
                }
                catch (Exception ex)
                {
                    connection.Close();
                    _logger.LogError(string.Format(Constant.LOG_Error_GetEmployeeList, ex.ToString()));
                    return null;
                }
                connection.Close();
                _logger.LogInfo(string.Format(Constant.LOG_Success_GetEmployeeList, result.Count()));
                return result;
            }
        }

        public Employee PostSaveEmployee(Employee inputEmployee)
        {
            if (inputEmployee == null)
            {
                _logger.LogError(string.Format(Constant.LOG_Error_PostSaveEmployee, Constant.NULL_Message));
                return null;
            }

            _logger.LogInfo(string.Format(Constant.LOG_Request_PostSaveEmployee, inputEmployee.Name));

            using (SqlConnection connection = new SqlConnection(_utility.SQLConnectiongString))
            {
                connection.Open();
                var actualresult = 0;
                //Get Expected Result of this Transaction
                var transaction = connection.BeginTransaction();
                try
                {
                    #region Creation of Request for Saving Employee Record
                    //Create Employee Request
                    _logger.LogInfo(string.Format(Constant.LOG_CreateRequest, Constant.LOG_Employee));
                    actualresult += _common.SaveRequest(transaction, (Request)inputEmployee);
                    //Log the Request Details created
                    _logger.LogInfo(string.Format(Constant.LOG_RequestDetails, inputEmployee.RequestID));
                    #endregion

                    #region Creation of Employee Transaction
                    //Create Employee Transaction
                    _logger.LogInfo(string.Format(Constant.LOG_CreateTransaction, Constant.LOG_Employee));
                    actualresult += SaveEmployee_TRN(transaction, inputEmployee);
                    //Log the Transaction Details created
                    _logger.LogInfo(string.Format(Constant.LOG_TransactionDetails, inputEmployee.RequestID, inputEmployee.EmployeeID));
                    #endregion

                    if (inputEmployee.RequestStatus == 0)
                    {
                        #region Saving of Employee Record in Master Table
                        //Save Employee
                        _logger.LogInfo(string.Format(Constant.LOG_Saving, Constant.LOG_Employee));
                        actualresult += _common.SaveEmployee_MST(transaction, inputEmployee);
                        #endregion
                    }

                    var expectedResult = inputEmployee.RequestStatus == 0 ? 3 + ((inputEmployee.ContactList.Count() + inputEmployee.AddressList.Count()) * 2) :
                                                                            2 + inputEmployee.ContactList.Count() + inputEmployee.AddressList.Count();

                    if ((inputEmployee.RequestStatus == 1 && actualresult < expectedResult - 1 ) || 
                        (inputEmployee.RequestStatus == 0 && actualresult < expectedResult))
                    {
                        _logger.LogError(string.Format(Constant.LOG_Error_PostSaveEmployee, Constant.PROBLEM_Message));
                        return null;
                    }

                    transaction.Commit();
                }   
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    connection.Close();
                    _logger.LogError(string.Format(Constant.LOG_Error_PostSaveEmployee, ex.ToString()));
                    return null;
                }
                connection.Close();
                _logger.LogInfo(string.Format(Constant.LOG_Success_PostSaveEmployee, inputEmployee.EmployeeID));
                return inputEmployee;
            }
        }

        private int SaveEmployee_TRN(SqlTransaction transaction, Employee inputEmployee)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Constant.StoredProcedureSaveEmployee_TRN;
                inputEmployee.EmployeeCommandParameters(command, false);
                var result = command.ExecuteNonQuery();
                inputEmployee.EmployeeID = command.Parameters["@EmployeeID"].Value.ToString();
                return result;
            }
        }
    }
}