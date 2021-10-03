using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentAdminEmployees.Application.Validation
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                string[] Phases = Convert.ToString(value).Split(' ');

                if (Phases.Length >= 3)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("must be name three phases");
                }
            }
            else
            {
                return new ValidationResult("not exext");
            }
        }
    }
}

