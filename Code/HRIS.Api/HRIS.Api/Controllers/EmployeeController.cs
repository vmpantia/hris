using HRIS.Model;
using HRIS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRIS.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        IEmployeeService _employee;
        public EmployeeController()
        {
            IUtilityService utility = new UtilityService();
            ICommonService common = new CommonService();
            _employee = new EmployeeService(common, utility);
        }

        [HttpPost]
        [Route("GetEmployeeList")]
        public List<Employee> GetEmployeeList(FilterSetting filterSetting)
        {
            return _employee.GetEmployeeList(filterSetting);
        }

        [HttpPost]
        [Route("PostSaveEmployee")]
        public Employee PostSaveEmployee(Employee inputEmployee)
        {
            return _employee.PostSaveEmployee(inputEmployee);
        }

    }
}
