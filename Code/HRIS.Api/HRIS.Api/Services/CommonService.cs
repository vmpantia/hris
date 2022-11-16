using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using HRIS.Model;
using HRIS.Logger;
using System.Data.SqlClient;
using HRIS.Api.Services.Extensions;

namespace HRIS.Api.Services
{
    public class CommonService : ICommonService
    {
        #region Request Service
        public int SaveRequest(SqlTransaction transaction, Request inputRequest)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Constant.StoredProcedureSaveRequest;
                inputRequest.RequestCommandParameters(command);
                var result =  command.ExecuteNonQuery();
                inputRequest.RequestID = command.Parameters["@RequestID"].Value.ToString();
                return result;
            }
        }
        #endregion

        #region Employee Service
        public int SaveEmployee_MST(SqlTransaction transaction, Employee inputEmployee)
        {
            using (var command = transaction.Connection.CreateCommand())
            {
                command.Transaction = transaction;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = Constant.StoredProcedureSaveEmployee_MST;
                inputEmployee.EmployeeCommandParameters(command, true);
                return command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}