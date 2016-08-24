using System;
using System.ComponentModel.DataAnnotations;

namespace UniversalReports.MVC.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class DateTimeGreaterThanAttribute : ValidationAttribute
    {
        public DateTimeGreaterThanAttribute(string dateFromFieldName)
            : base(string.Empty)
        {
            DateFromFieldName = dateFromFieldName;
        }

        public string DateFromFieldName { get; }

        public override string FormatErrorMessage(string name) => "End date can't be less than start date";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valid = IsValidationContext(validationContext) && IsValidDateRange(value, validationContext);

            return valid
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private bool IsValidationContext(ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(DateFromFieldName);
            return property != null;
        }

        private bool IsValidDateRange(object value, ValidationContext validationContext)
        {
            var dateFrom = GetDateFrom(validationContext);
            var dateTo = (DateTime)value;
            return dateTo >= dateFrom;
        }

        private DateTime GetDateFrom(ValidationContext context)
        {
            var property = context.ObjectType.GetProperty(DateFromFieldName);
            return (DateTime)property.GetValue(context.ObjectInstance, null);
        }
    }
}