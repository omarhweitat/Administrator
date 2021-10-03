using AssignmentAdminEmployees.Application.DTO;
using AssignmentAdminEmployees.Application.Interface;
using AssignmentAdminEmployees.Application.ViewModul;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.UI.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public void ReFullList()
        {
            ViewData["GetStatus"] = new SelectList(_employeeService.GETSTATUS(), "STATUS_ID", "STATUS_DESC");
            ViewData["GetDepartment"] = new SelectList(_employeeService.GETDEPARTMENTS(), "DEPARTMENT_ID", "DEPARTMENT_DESC");
            ViewData["GetGender"] = new SelectList(_employeeService.GETGENDERS(), "GENDER_ID", "GENDER_DESC");
        }
        [HttpGet]
        public IActionResult Index()
        {
            ReFullList();
            return View();
        }
       
        [HttpGet]
        public IActionResult Create()
        {
            ReFullList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            var UserIdSignIn = HttpContext.User.Claims.Where(x => x.Type == "Uid").SingleOrDefault();
            if (ModelState.IsValid)
            {
                var Employee = new EmployeeDTO()
                {
                    EMPLOYEE_NAME_LANG1=employeeVM.EMPLOYEE_NAME_LANG1,
                    EMPLOYEE_NAME_LANG2=employeeVM.EMPLOYEE_NAME_LANG2,
                    EMAIL_ADDRERSS=employeeVM.EMAIL_ADDRERSS,
                    MOBILE=employeeVM.MOBILE,
                    EMPLOYEE_STATUS_ID=employeeVM.EMPLOYEE_STATUS_ID,
                    EMPLOYEE_DEPARTMENT_ID=employeeVM.EMPLOYEE_DEPARTMENT_ID,
                    WORKING_HOUR_FROM=employeeVM.WORKING_HOUR_FROM,
                    WORKING_HOUR_TO=employeeVM.WORKING_HOUR_TO,
                    USER_ADD = Convert.ToDecimal(UserIdSignIn.Value),
                    AGE=employeeVM.AGE,
                    SALARY=employeeVM.SALARY,
                    GENDER_ID=employeeVM.GENDER_ID
                };
                _employeeService.CreateEmployee(Employee);
                return RedirectToAction("Index");
            }
            ReFullList();
            return View(employeeVM);
        }
        [HttpGet]
        public IActionResult Edite(decimal Id)
        {
            ReFullList();
            if ( Id == 0)
            {
                return NotFound();
            }
            var employee = _employeeService.FindEmployee(Id);

            var Employee = new EmployeeVM()
            {
                EMPLOYEE_ID=Id,
                EMPLOYEE_NAME_LANG1 = employee.EMPLOYEE_NAME_LANG1,
                EMPLOYEE_NAME_LANG2 = employee.EMPLOYEE_NAME_LANG2,
                EMAIL_ADDRERSS = employee.EMAIL_ADDRERSS,
                MOBILE = employee.MOBILE,
                EMPLOYEE_STATUS_ID = employee.EMPLOYEE_STATUS_ID,
                EMPLOYEE_DEPARTMENT_ID = employee.EMPLOYEE_DEPARTMENT_ID,
                WORKING_HOUR_FROM = employee.WORKING_HOUR_FROM,
                WORKING_HOUR_TO = employee.WORKING_HOUR_TO,
                AGE = employee.AGE,
                SALARY = employee.SALARY,
                GENDER_ID =Convert.ToInt32( employee.GENDER_ID)
            };
            if (Employee == null)
            {
                return NotFound();
            }
            
            return View(Employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edite(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                var Employee = new EmployeeDTO()
                {
                    EMPLOYEE_ID = employeeVM.EMPLOYEE_ID,
                    EMPLOYEE_NAME_LANG1 = employeeVM.EMPLOYEE_NAME_LANG1,
                    EMPLOYEE_NAME_LANG2 = employeeVM.EMPLOYEE_NAME_LANG2,
                    EMAIL_ADDRERSS = employeeVM.EMAIL_ADDRERSS,
                    MOBILE = employeeVM.MOBILE,
                    EMPLOYEE_STATUS_ID = employeeVM.EMPLOYEE_STATUS_ID,
                    EMPLOYEE_DEPARTMENT_ID = employeeVM.EMPLOYEE_DEPARTMENT_ID,
                    WORKING_HOUR_FROM = employeeVM.WORKING_HOUR_FROM,
                    WORKING_HOUR_TO = employeeVM.WORKING_HOUR_TO,
                    AGE = employeeVM.AGE,
                    SALARY = employeeVM.SALARY,
                    GENDER_ID =employeeVM.GENDER_ID

                };
                _employeeService.UpdateEmployee(Employee);
                return RedirectToAction("Index");
            }
            ReFullList();
            return View(employeeVM);
        }
        [HttpGet]
        public IActionResult Delete(decimal Id)
        {

            ReFullList();
            if (Id == 0)
            {
                return NotFound();
            }
            var employee = _employeeService.FindEmployee(Id);

            var Employee = new EmployeeVM()
            {
                EMPLOYEE_ID = Id,
                EMPLOYEE_NAME_LANG1 = employee.EMPLOYEE_NAME_LANG1,
                EMPLOYEE_NAME_LANG2 = employee.EMPLOYEE_NAME_LANG2,
                EMAIL_ADDRERSS = employee.EMAIL_ADDRERSS,
                MOBILE = employee.MOBILE,
                EMPLOYEE_STATUS_ID = employee.EMPLOYEE_STATUS_ID,
                EMPLOYEE_DEPARTMENT_ID = employee.EMPLOYEE_DEPARTMENT_ID,
                WORKING_HOUR_FROM = employee.WORKING_HOUR_FROM,
                WORKING_HOUR_TO = employee.WORKING_HOUR_TO,
                AGE = employee.AGE,
                SALARY = employee.SALARY,
                GENDER_ID = Convert.ToInt32(employee.GENDER_ID)
            };
            if (Employee == null)
            {
                return NotFound();
            }

            return View(Employee);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(decimal? Id)
        {
            _employeeService.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(decimal Id)
        {
            ReFullList();
            if (Id == 0)
            {
                return NotFound();
            }
            var employee = _employeeService.FindEmployee(Id);

            var Employee = new EmployeeVM()
            {
                EMPLOYEE_ID = Id,
                EMPLOYEE_NAME_LANG1 = employee.EMPLOYEE_NAME_LANG1,
                EMPLOYEE_NAME_LANG2 = employee.EMPLOYEE_NAME_LANG2,
                EMAIL_ADDRERSS = employee.EMAIL_ADDRERSS,
                MOBILE = employee.MOBILE,
                EMPLOYEE_STATUS_ID = employee.EMPLOYEE_STATUS_ID,
                EMPLOYEE_DEPARTMENT_ID = employee.EMPLOYEE_DEPARTMENT_ID,
                WORKING_HOUR_FROM = employee.WORKING_HOUR_FROM,
                WORKING_HOUR_TO = employee.WORKING_HOUR_TO,
                AGE = employee.AGE,
                SALARY = employee.SALARY,
                GENDER_ID = Convert.ToInt32(employee.GENDER_ID)
            };
            if (Employee == null)
            {
                return NotFound();
            }

            return View(Employee);
        }
       public IActionResult Statistical_Report()
        {
            return View();
        }
        public IActionResult Statistical_Report_Age()
        {
            return View();
        }

    }
}
