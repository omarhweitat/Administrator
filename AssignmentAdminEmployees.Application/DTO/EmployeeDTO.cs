using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.DTO
{
    public class EmployeeDTO
    {
        public decimal EMPLOYEE_ID { get; set; }
        public string EMPLOYEE_NAME_LANG1 { get; set; }
        public string EMPLOYEE_NAME_LANG2 { get; set; }
        public string EMAIL_ADDRERSS { get; set; }
        public string WORKING_HOUR_FROM { get; set; }
        public string WORKING_HOUR_TO { get; set; }
        public string MOBILE { get; set; }
        public decimal EMPLOYEE_STATUS_ID { get; set; }
        public decimal EMPLOYEE_DEPARTMENT_ID { get; set; }
        public decimal? USER_ADD { get; set; }
        public decimal? GENDER_ID { get; set; }
        public int AGE { get; set; }
        public decimal SALARY { get; set; }
    }
}
