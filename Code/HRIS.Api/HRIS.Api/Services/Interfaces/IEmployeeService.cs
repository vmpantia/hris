using HRIS.Model;
using System.Collections.Generic;

namespace HRIS.Api.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployeeList(FilterSetting filterSetting);
        Employee PostSaveEmployee(Employee inputEmployee);
    }
}