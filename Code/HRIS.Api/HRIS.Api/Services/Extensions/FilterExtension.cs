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
    internal static class FilterExtension
    {
        public static void FilterCommandParameters(this FilterSetting inputFilter, SqlCommand command)
        {
            SqlParameter[] parameter = new[]
            {
                new SqlParameter("@FilterBy", SqlDbType.VarChar) { Value = inputFilter.FilterBy },
                new SqlParameter("@FilterValue", SqlDbType.VarChar) { Value = inputFilter.FilterValue },
                new SqlParameter("@FilterFromDate", SqlDbType.DateTime) { Value = inputFilter.FilterFromDate ?? SqlDateTime.Null },
                new SqlParameter("@FilterToDate", SqlDbType.DateTime) { Value = inputFilter.FilterToDate ?? SqlDateTime.Null },
                new SqlParameter("@PageNo", SqlDbType.Int) { Value = inputFilter.PageNo },
                new SqlParameter("@PageSize", SqlDbType.Int) { Value = inputFilter.PageSize }
            };
            command.Parameters.AddRange(parameter);
        }
    }
}