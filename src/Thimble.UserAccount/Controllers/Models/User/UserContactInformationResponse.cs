using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Thimble.UserAccount.Controllers.Models.Address;
using Thimble.UserAccount.Controllers.Models.Name;
using Thimble.UserAccount.Controllers.Models.Registration.Validation;

namespace Thimble.UserAccount.Controllers.Models.User
{
    public class UserContactInformationResponse
    {
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        public string UserId { get; set; }
        
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        public string Email { get; set; }

        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        public NameRequest Name { get; set; }
        
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        [PhoneNumberValidation]
        public string PhoneNumber { get; set; }
        
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)] 
        public AddressResponse Address { get; set; }
    }
}