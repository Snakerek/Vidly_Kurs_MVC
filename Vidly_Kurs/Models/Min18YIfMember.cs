using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Vidly_Kurs.Models
{
    public class Min18YIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId==MembershipType.OplataNaZadanie)
            {
                return  ValidationResult.Success;              
            }

            if (customer.MembershipTypeId == MembershipType.Unknown)
            {
               return new ValidationResult("Wybierz typ subskrypcji");
            }
            else
            {
                if (customer.BirthdayDate==null)
            {
                return new ValidationResult("Data urodzenia jest wymagana");
            }
            var age = DateTime.Today.Year - customer.BirthdayDate.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Użytkownik nie jest pełnoletni"); 
            }

           
        }
    }
}