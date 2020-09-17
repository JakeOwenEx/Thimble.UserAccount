using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thimble.UserAccount.AWS.Dynamo.ContactInformation;
using Thimble.UserAccount.Controllers.Authorization;
using Thimble.UserAccount.Controllers.Models.Registration;
using Thimble.UserAccount.Controllers.Models.User;
using Thimble.UserAccount.Controllers.TraceId;
using Thimble.UserAccount.logging;

namespace Thimble.UserAccount.Controllers
{
    [Route("useraccount/")]
    [ApiController]
    [Authorization]
    [TraceIdResolver]
    public class UserAccountController : ControllerBase
    {
        private readonly IContactInformationDynamoClient _contactInformationDynamoClient;
        private readonly IThimbleLogger _thimbleLogger;
        
        public UserAccountController(
            IContactInformationDynamoClient contactInformationDynamoClient,
            IThimbleLogger thimbleLogger)
        {
            _contactInformationDynamoClient = contactInformationDynamoClient;
            _thimbleLogger = thimbleLogger;
        }
        
        [HttpPost("register")]
        public async Task<RegistrationResponse> RegisterUser([FromBody] RegisterUserRequest userRequest)
        {
            _thimbleLogger.Log(userRequest.UserId, "useraccount.registration.started");
            await _contactInformationDynamoClient.RegisterUser(userRequest);
            return new RegistrationResponse{UserId = userRequest.UserId};
        }

        [HttpGet("{userId}/contactInformation")]
        public async Task<UserContactInformationResponse> GetAllContactInformation(string userId)
        {
            _thimbleLogger.Log(userId, "useraccount.getcontactinfo.started");
            return await _contactInformationDynamoClient.GetUserById($"{userId}");
        }
        
        [HttpGet("{userId}/contactInformation/{key}")]
        public async Task<UserContactInformationResponse> GetEntryInContactInformation(string userId, string key)
        {
            _thimbleLogger.Log(userId, "useraccount.registration.started");
            return await _contactInformationDynamoClient.GetEntryInContactInformation($"{userId}", $"{key}");
        }

    }
}
