using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Vidly.Models
{
    public class Min18YearIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer=(Customer)validationContext.ObjectInstance;//containing class
            if (customer.MembershipTypeId == 0||customer.MembershipTypeId == 1)//1=pay as you go 0=unknown value
            {
                return ValidationResult.Success;
            }

            if (customer.DOB == null)
            {
                return new ValidationResult("Birthday is Required");
            }
            var age = (int)(DateTime.Today.Year) - (int)customer.DOB.Value.Year;
       
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Atlest 18 year old");
        }
    }
}