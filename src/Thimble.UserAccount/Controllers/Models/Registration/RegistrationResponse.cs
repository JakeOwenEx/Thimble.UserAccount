using Newtonsoft.Json;

namespace Thimble.UserAccount.Controllers.Models.Registration
{
    public class RegistrationResponse
    {
        [JsonProperty] 
        public string UserId { get; set; }
    }
}