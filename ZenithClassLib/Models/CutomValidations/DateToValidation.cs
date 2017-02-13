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
        private int productNameWordCount;

        public DateToValidation()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dateTo = (DateTime) value;

                //if (dateTo)
            }

            return ValidationResult.Success;
        }
    }
}
