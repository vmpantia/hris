using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS.Model;

namespace HRIS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            var employeeList = new List<Employee>();
            return View(employeeList);
        }

        public ActionResult EditEmployee(Guid internalID)
        {
            var employee = new Employee();
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee inputEmployee)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(inputEmployee);
        }
    }
}