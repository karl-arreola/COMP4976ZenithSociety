using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenithDataLib.Models.CutomValidations
{
    class DateToValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentEvent = (Models.Event)validationContext.ObjectInstance;
            DateTime dateTo = Convert.ToDateTime(value);
            DateTime dateFrom = Convert.ToDateTime(currentEvent.DateFrom);

            if (dateTo > dateFrom)
            {
                return ValidationResult.Success;
            }
            else
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
        }
    }
}
