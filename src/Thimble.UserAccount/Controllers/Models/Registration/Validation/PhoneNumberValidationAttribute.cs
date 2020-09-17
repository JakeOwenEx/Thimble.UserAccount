using System;
using System.ComponentModel.DataAnnotations;

namespace Thimble.UserAccount.Controllers.Models.Registration.Validation
{
    public class PhoneNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var phoneNumber = (string) value;
            var phoneNumberUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            try
            {
                
                var phObj = phoneNumberUtil.Parse(phoneNumber, "GB");
                if (phoneNumberUtil.IsValidNumber(phObj))
                {
                    return ValidationResult.Success;   
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(ex.Message);
            }
            return new ValidationResult("Invalid Phone Number");
        }
    }
}