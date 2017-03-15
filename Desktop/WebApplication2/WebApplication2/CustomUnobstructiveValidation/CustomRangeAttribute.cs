using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.CustomUnobstructiveValidation
{
    public class CustomRangeAttribute : ValidationAttribute, IClientValidatable
    {

        public int Min;
        public int Max;
        public const string DefaultErrorMessage= "'{0}' must be a date between {1} and {2}";
        public CustomRangeAttribute(int max,int min):base(DefaultErrorMessage)
        {
            Min = min;
            Max = max;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(DefaultErrorMessage, name,Min,Max);
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            { return true; }
            int n = (int)value;
            return Min <= n && n <= Max;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            throw new NotImplementedException();
        }

    }
}