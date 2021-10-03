using AssignmentAdminEmployees.Application.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.ViewModul
{
    public class EmployeeVM
    {
        public decimal EMPLOYEE_ID { get; set; }
        [Required]
        [Display(Name = "name english")]
        [NameValidation]
        public string EMPLOYEE_NAME_LANG1 { get; set; }
        [Required]
        [Display(Name = "name Arabic")]
        public string EMPLOYEE_NAME_LANG2 { get; set; }
        [Required]
        [Display(Name = "email")]
        public string EMAIL_ADDRERSS { get; set; }
        [Required]
        [Display(Name = "start work")]
        public string WORKING_HOUR_FROM { get; set; }
        [Required]
        [Display(Name = "end work")]
        public string WORKING_HOUR_TO { get; set; }
        [Required]

        [RegularExpression("^\\(?([0-9]{3})\\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$",ErrorMessage ="must be phone number")]
        public string MOBILE { get; set; }
        [Required]
        [Display(Name = "status")]
        public decimal EMPLOYEE_STATUS_ID { get; set; }
        [Required]
        [Display(Name = "department")]
        public decimal EMPLOYEE_DEPARTMENT_ID { get; set; }
        public decimal? USER_ADD { get; set; }
        [Required]
        [Display(Name = "gender")]
        public decimal? GENDER_ID { get; set; }
        [Required]
        [AgeValidation]
        [Display(Name = "age")]
        public int AGE { get; set; }
        [Required]
        [SalaryValidation]
        [Display(Name = "salary")]
        public decimal SALARY { get; set; }
    }
}
