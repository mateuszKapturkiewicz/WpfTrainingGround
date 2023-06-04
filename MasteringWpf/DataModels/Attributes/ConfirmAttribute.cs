using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MasteringWpf.DataModels.Attributes
{
    class ConfirmAttribute : ValidationAttribute
    {
        private string otherPropertyName = null;

        /// <summary>
        /// Initialises a new ConfirmAttribute object with the value from the input parameter.
        /// </summary>
        /// <param name="otherPropertyName">The name of the property to compare with the input value.</param>
        public ConfirmAttribute(string otherPropertyName)
        {
            this.otherPropertyName = otherPropertyName;
        }

        /// <summary>
        /// Validates the specified value with respect to the current validation attribute.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>An instance of the System.ComponentModel.DataAnnotations.ValidationResult class.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value.GetType() != typeof(string) || value == null) return ReturnErrorValidationResult(validationContext);
            else
            {
                PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(otherPropertyName);
                if (propertyInfo == null) throw new ArgumentNullException($"Unknown property: {otherPropertyName}");
                object otherPropertyValue = propertyInfo.GetValue(validationContext.ObjectInstance);
                if (otherPropertyValue.ToString() == value.ToString()) return ValidationResult.Success;
                return ReturnErrorValidationResult(validationContext);
            }
        }

        private ValidationResult ReturnErrorValidationResult(ValidationContext validationContext)
        {
            string[] memberNames = new string[] { validationContext.MemberName };
            return new ValidationResult(ErrorMessage, memberNames);
        }
    }
}
