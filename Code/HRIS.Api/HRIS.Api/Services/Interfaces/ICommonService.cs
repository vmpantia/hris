using HRIS.Model;
using System.Data.SqlClient;

namespace HRIS.Api.Services
{
    public interface ICommonService
    {
        int SaveRequest(SqlTransaction transaction, Request inputRequest);
        int SaveEmployee_MST(SqlTransaction transaction, Employee inputEmployee);
    }
}