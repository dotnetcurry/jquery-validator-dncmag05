using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CustomJqueryValidator.Validators
{
    public class DynamicLengthValidationAttribute : ValidationAttribute, IClientValidatable
    {
        string _validationField, _dataLengthField, _returnField;
        int _requiredLength;

        public DynamicLengthValidationAttribute
            (string validationField, string dataLengthField, string returnfield)
        {
            _validationField = validationField;
            _dataLengthField = dataLengthField;
            _returnField = returnfield;
        }

        public override bool IsValid(object value)
        {
            return value.ToString().Length == _requiredLength;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propInfo = validationContext.ObjectType.GetProperty(_returnField);
            _requiredLength = (int)propInfo.GetValue(validationContext.ObjectInstance);
            return base.IsValid(value, validationContext);
        }


        public IEnumerable<ModelClientValidationRule> GetClientValidationRules
            (ModelMetadata metadata, ControllerContext context)
        {
            var rule = new DynamicLengthClientValidationRule
                        (ErrorMessage, _validationField, _dataLengthField, _returnField);
            yield return rule;
        }
    }
}