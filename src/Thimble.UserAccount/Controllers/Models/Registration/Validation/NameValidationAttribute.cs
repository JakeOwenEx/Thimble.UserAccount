using System.ComponentModel.DataAnnotations;

namespace Thimble.UserAccount.Controllers.Models.Registration.Validation
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string name = (string) value;
            if (name.Length > 50)
            {
                return new ValidationResult("Name is above max limit [51 characters]");
            }
            return ValidationResult.Success;
        }
    }
}