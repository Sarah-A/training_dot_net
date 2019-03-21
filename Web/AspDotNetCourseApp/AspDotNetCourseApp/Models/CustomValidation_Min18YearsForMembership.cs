using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace AspDotNetCourseApp.Models
{
    public class CustomValidation_Min18YearsForMembership : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            return ValidateBirhtdate(customer.Birthdate, 18);            

        }

        private ValidationResult ValidateBirhtdate(DateTime? birthdate, int minAge)
        {
            if (birthdate == null)
            {
                return new ValidationResult("Birthdate is required to choose memebership."); 
                                            //new string[] { "Birthdate" });
            }

            var age = DateTime.Now.Year - birthdate.Value.Year;
            if (age < minAge)
            {
                return new ValidationResult($"Customer must be at least {minAge} to sign up to membership");
            }

            return ValidationResult.Success;
        }

    }
}