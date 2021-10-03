using AssignmentAdminEmployees.Application.Interface;
using AssignmentAdminEmployees.Application.TableDataModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.UI.MVC.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApiController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public object GetEmployeeDataTable(DataTableRequest model)
        {
            var Data = _employeeService.PostEmployeeTableDataJson(model);
            return Data;
        }
        [HttpPost]
        [Route("GetData")]
        public object GetData()
        {
            int Male = _employeeService.GetEMPLOYEES().Where(x => x.GENDER_ID == 1&& x.RECORDSTATUS==2).Count();
            int Female = _employeeService.GetEMPLOYEES().Where(x => x.GENDER_ID == 2&& x.RECORDSTATUS == 2).Count();
            Gender_Data obj =new Gender_Data()
            {
                male = Male,
                female=Female
            };
            return obj;
        }
        [HttpPost]
        [Route("GetDataAge")]
        public object GetDataAge()
        {
            int Age20_30 = _employeeService.GetEMPLOYEES().Where(x => x.AGE >= 20 && x.AGE <= 30).Count();
            int Age30_40 = _employeeService.GetEMPLOYEES().Where(x => x.AGE >= 30 && x.AGE < 40).Count();
            int Age40_50 = _employeeService.GetEMPLOYEES().Where(x => x.AGE >= 40 && x.AGE < 50).Count();
            int Age50_60 = _employeeService.GetEMPLOYEES().Where(x => x.AGE >= 50 && x.AGE <= 60).Count();
            Age_Data obj = new Age_Data()
            {
                age1 = Age20_30,
                age2 = Age30_40,
                age3 = Age40_50,
                age4 = Age50_60,
            };
            return obj;
        }
        public class Age_Data
        {
            public int age1 { get; set; }
            public int age2 { get; set; }
            public int age3 { get; set; }
            public int age4 { get; set; }
        }
        public class Gender_Data
        {
            public int male { get; set; }
            public int female { get; set; }
        }
    }
}
