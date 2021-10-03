using AssignmentAdminEmployees.Application.Interface;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.UI.MVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public ReportController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
       
        [HttpPost]
        public IActionResult ExportEmployeeActive()
        {
            DataTable dt = new DataTable("EmployeeActiveReport");
            dt.Columns.AddRange(new DataColumn[10] { new DataColumn("Name"),
                                        new DataColumn("Name Arabic"),
                                        new DataColumn("Email Address"),
                                        new DataColumn("Working From"),
                                        new DataColumn("Working To"),
                                        new DataColumn("Mobile"),
                                        new DataColumn("Department"),
                                         new DataColumn("Gender"),
                                        new DataColumn("Age"),
                                        new DataColumn("Salary"),
                                       });



            var EmployeeActive = from Employee in _employeeService.GetEmpolyeeActive().ToList()
                                      select Employee;

            foreach (var Employee in EmployeeActive)
            {
                dt.Rows.Add(Employee.Name,Employee.NameArabic,Employee.Email,Employee.Working_From,Employee.Working_to,Employee.Modile
                    ,Employee.Department ,Employee.Gender ,Employee.Age ,Employee.Salary);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeeActiveReport.xlsx");
                }
            }
        }
    }
}
