using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.Validation
{
    public class SalaryValidationAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {

                var Salary = Convert.ToInt32(value);
                if (Salary >= 300 & Salary <= 5000)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Age must be between 300 and 5000");
                }
            }
            else
            {
                return new ValidationResult("not exext");
            }
        }
    }
}
