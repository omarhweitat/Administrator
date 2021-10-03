using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.Validation
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {

                var age = Convert.ToInt32(value);
                if (age >= 22 & age<=  60 )
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Age must be between 22 and 60");
                }
            }
            else
            {
                return new ValidationResult("not exext");
            }
        }
    }
}
