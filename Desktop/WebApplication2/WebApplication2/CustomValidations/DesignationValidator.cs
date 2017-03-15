using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class DesignationValidator
    {
        public static ValidationResult IsDesignationValid(string designation, ValidationContext context)
        {
            if (string.IsNullOrWhiteSpace(designation))
                return new ValidationResult("Designation cannot be null or white space");
            if (designation.ToLower().Equals("senior") || designation.ToLower().Equals("junior"))
                return ValidationResult.Success;
            return new ValidationResult("Designation can be either senior or junior only");
        }
    }
}