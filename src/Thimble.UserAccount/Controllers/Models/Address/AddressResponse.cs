using Newtonsoft.Json;

namespace Thimble.UserAccount.Controllers.Models.Address
{
    public class AddressResponse
    {
        [JsonProperty] 
        public string AddressLine1 { get; set; }
        
        [JsonProperty]
        public string AddressLine2 { get; set; }
        
        [JsonProperty] 
        public string City { get; set; }
        
        [JsonProperty] 
        public string County { get; set; }
        
        [JsonProperty] 
        public string Postcode { get; set; }
    }
}