using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Thimble.UserAccount.Controllers.Models.Registration.Validation;

namespace Thimble.UserAccount.Controllers.Models.Name
{
    public class NameRequest
    {
        [Required]
        [JsonProperty]
        [NameValidation]
        public string FirstName { get; set; }
        
        [Required]
        [JsonProperty]
        [NameValidation]
        public string LastName { get; set; }
    }
}