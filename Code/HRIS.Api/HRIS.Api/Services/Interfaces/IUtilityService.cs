using HRIS.Model;
using HRIS.Logger;
using System.Data;

namespace HRIS.Api.Services
{
    public interface IUtilityService
    {
        ILoggerManager GetLoggerManager();
        string SQLConnectiongString { get; }
        Employee ParseEmployee(DataRow dataRow);
    }
}