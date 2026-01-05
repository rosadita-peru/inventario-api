using System;
using System.ComponentModel.DataAnnotations;

namespace invetario_api.Validations;

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime dateValue)
        {
            if (dateValue > new DateTime(1990, 1, 1))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The date must be after January 1, 1990.");
            }
        }
        return new ValidationResult("Invalid date format.");
    }
}
