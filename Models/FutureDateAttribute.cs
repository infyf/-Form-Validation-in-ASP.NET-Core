using System;
using System.ComponentModel.DataAnnotations;

namespace lr10.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                if (dateTime <= DateTime.Now)
                {
                    return new ValidationResult(ErrorMessage);
                }
                if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    return new ValidationResult("Дата не може бути у вихідні дні.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
