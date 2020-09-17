using System.Collections.Generic;
using System.Threading.Tasks;
using Thimble.UserAccount.AWS.Dynamo.ContactInformation.Exceptions;
using Thimble.UserAccount.AWS.Dynamo.ContactInformation.Models;
using Thimble.UserAccount.Controllers.Models.Address;
using Thimble.UserAccount.Controllers.Models.Name;
using Thimble.UserAccount.Controllers.Models.User;

namespace Thimble.UserAccount.AWS.Dynamo.ContactInformation.Helpers
{
    public static class UserResponseMapper
    {
        public static class AllDetails
        {
            public static async Task <UserContactInformationResponse> Map(
                List<ContactInformationEntryDynamo> dynamoResponse)
            {
                if (dynamoResponse.Count == 0)
                {
                    throw new UserNotFoundException();
                }
                        
                var user = dynamoResponse[0];
                        
                return new UserContactInformationResponse
                {
                    UserId = user.UserId, 
                    Email = user.Email, 
                    Name = new NameRequest 
                    {
                        FirstName = user.FirstName, 
                        LastName = user.LastName
                    },
                    PhoneNumber = user.PhoneNumber,
                    Address = new AddressResponse()
                    {
                        AddressLine1 = user.AddressLine1,
                        AddressLine2 = user.AddressLine2,
                        City = user.City,
                        County = user.County,
                        Postcode = user.Postcode
                    }
                };
            }
        }

        public static class PartialDetails
        {
            public static UserContactInformationResponse Map(
                UserContactInformationResponse user, string key)
            {
                var response = new UserContactInformationResponse();
            
                switch (key.ToLower())
                {
                    case "name":
                        response.Name = user.Name;
                        break;
                    case "address":
                        response.Address = user.Address;
                        break;
                    case "email":
                        response.Email = user.Email;
                        break;
                    case "phonenumber":
                        response.PhoneNumber= user.PhoneNumber;
                        break;
                    default:
                        throw new InvalidKeyException();
                }

                return response;
            }
        }
    }
}