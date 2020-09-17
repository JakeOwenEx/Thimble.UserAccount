using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Thimble.UserAccount.Controllers.Models.Address
{
    public class AddressRequest
    {
        [Required]
        [JsonProperty] 
        public string AddressLine1 { get; set; }
        
        [JsonProperty] 
        public string AddressLine2 { get; set; }
        
        [Required]
        [JsonProperty] 
        public string City { get; set; }
        
        [Required]
        [JsonProperty] 
        public string County { get; set; }
        
        [Required]
        [JsonProperty] 
        public string Postcode { get; set; }
    }
}