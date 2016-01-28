using System;
using System.ComponentModel.DataAnnotations;

namespace UniversalReports.MVC.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DateTimeGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _dateFromFieldName;

        public DateTimeGreaterThanAttribute(string dateFromFieldName)
            : base(string.Empty)
        {
            _dateFromFieldName = dateFromFieldName;
        }

        public override string FormatErrorMessage(string name)
        {
            return "End date can't be less than start date";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valid = IsValidationContext(validationContext) && IsValidDateRange(value, validationContext);

            return valid
                ? ValidationResult.Success
                : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }

        private bool IsValidationContext(ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty(_dateFromFieldName);
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
            var property = context.ObjectType.GetProperty(_dateFromFieldName);
            return (DateTime)property.GetValue(context.ObjectInstance, null);
        }
    }
}