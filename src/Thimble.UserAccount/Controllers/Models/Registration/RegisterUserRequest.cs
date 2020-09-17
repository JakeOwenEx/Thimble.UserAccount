using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Thimble.UserAccount.Controllers.Models.Address;
using Thimble.UserAccount.Controllers.Models.Name;
using Thimble.UserAccount.Controllers.Models.Registration.Validation;

namespace Thimble.UserAccount.Controllers.Models.Registration
{
    public class RegisterUserRequest
    {
        [Required]
        [JsonProperty] 
        public string UserId { get; set; }
        
        [Required]
        [JsonProperty] 
        public string Email { get; set; }
        
        [Required]
        [JsonProperty] 
        public NameRequest Name { get; set; }
        
        [Required]
        [JsonProperty] 
        [PhoneNumberValidation]
        public string PhoneNumber { get; set; }
        
        [Required]
        [JsonProperty] 
        public AddressRequest Address { get; set; }
    }
}