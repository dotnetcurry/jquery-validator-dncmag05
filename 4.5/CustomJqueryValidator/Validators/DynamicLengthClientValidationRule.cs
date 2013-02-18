using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomJqueryValidator.Validators
{
    public class DynamicLengthClientValidationRule: ModelClientValidationRule
    {
        public DynamicLengthClientValidationRule(string errorMessage, 
            string validationField, string dataLengthField, string returnfield)
        {
            ErrorMessage = !string.IsNullOrEmpty(errorMessage) ? 
                errorMessage : "Dynamic length validation failed";
            ValidationType = "dynamicmaxlength";
            ValidationParameters.Add("validationfield", validationField);
            ValidationParameters.Add("datalengthfield", dataLengthField);
            ValidationParameters.Add("returnfield", returnfield);
        }
    }
}