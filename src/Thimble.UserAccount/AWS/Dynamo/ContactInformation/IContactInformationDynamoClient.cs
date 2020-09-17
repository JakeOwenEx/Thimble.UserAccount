using System.Threading.Tasks;
using Thimble.UserAccount.Controllers.Models.Registration;
using Thimble.UserAccount.Controllers.Models.User;

namespace Thimble.UserAccount.AWS.Dynamo.ContactInformation
{
    public interface IContactInformationDynamoClient
    {
        Task RegisterUser(RegisterUserRequest registerRequest);
        Task<UserContactInformationResponse> GetEntryInContactInformation(string userId, string key);

        Task<UserContactInformationResponse> GetUserById(string userId);
    }
}