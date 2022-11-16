using HRIS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace HRIS.Api.Services.Extensions
{
    internal static class RequestServiceExtension
    {
        public static void RequestCommandParameters(this Request inputRequest, SqlCommand command)
        {
            SqlParameter[] parameter = new[]
            {
                new SqlParameter("@RequestID", SqlDbType.VarChar, 15) { Value = inputRequest.RequestID, Direction = ParameterDirection.InputOutput },
                new SqlParameter("@FunctionID", SqlDbType.VarChar, 5) { Value = inputRequest.FunctionID },
                new SqlParameter("@RequestStatus", SqlDbType.Int) { Value = inputRequest.RequestStatus },
                new SqlParameter("@RequestBy", SqlDbType.UniqueIdentifier) { Value = inputRequest.RequestBy ?? SqlGuid.Null },
                new SqlParameter("@RequestDate", SqlDbType.DateTime) { Value = inputRequest.RequestDate },
                new SqlParameter("@ApprovedBy", SqlDbType.UniqueIdentifier) { Value = inputRequest.ApprovedBy ?? SqlGuid.Null },
                new SqlParameter("@ApprovedDate", SqlDbType.DateTime) { Value = inputRequest.ApprovedDate ?? SqlDateTime.Null },
                new SqlParameter("@CompletedDate", SqlDbType.DateTime) { Value = inputRequest.CompletedDate ?? SqlDateTime.Null },
                new SqlParameter("@LastModifiedDate", SqlDbType.DateTime) { Value = inputRequest.LastModifiedDate ?? SqlDateTime.Null },
            };
            command.Parameters.AddRange(parameter);
        }
    }
}