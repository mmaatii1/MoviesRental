using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesRental.Models
{
    public class Min18Yo : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if(customer.MemberShipId == MemberShip.Free)
                return ValidationResult.Success;
            if(customer.DateOfBirth == null)
                return new ValidationResult("Enter birthday");
            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;

            return age>=MemberShip.MinAge ? ValidationResult.Success : new ValidationResult("Customer must be at least 18yo to have a membership");
        }
    }
}
