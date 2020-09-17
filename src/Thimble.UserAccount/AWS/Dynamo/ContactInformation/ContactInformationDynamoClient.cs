using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Thimble.UserAccount.AWS.AwsClient;
using Thimble.UserAccount.AWS.Dynamo.ContactInformation.Helpers;
using Thimble.UserAccount.AWS.Dynamo.ContactInformation.Models;
using Thimble.UserAccount.Controllers.Models.Registration;
using Thimble.UserAccount.Controllers.Models.User;

namespace Thimble.UserAccount.AWS.Dynamo.ContactInformation
{
    public class ContactInformationDynamoClient : IContactInformationDynamoClient
    {
        private readonly AmazonDynamoDBClient _dynamoClient;
        
        public ContactInformationDynamoClient(IAwsService awsService)
        {
            _dynamoClient = awsService.GetDynamoClient();
        }

        public async Task RegisterUser(RegisterUserRequest registerRequest)
        {
            await _dynamoClient.PutItemAsync(DynamoConstants.PII_TABLE, new Dictionary<string, AttributeValue>
            {
                {DynamoConstants.UserIdKey, new AttributeValue(registerRequest.UserId)},
                {DynamoConstants.EmailKey, new AttributeValue(registerRequest.Email)},
                {DynamoConstants.FirstNameKey, new AttributeValue(registerRequest.Name.FirstName)},
                {DynamoConstants.LastNameKey, new AttributeValue(registerRequest.Name.LastName)},
                {DynamoConstants.PhoneNumberKey, new AttributeValue(registerRequest.PhoneNumber)},
                {DynamoConstants.AddressLine1Key, new AttributeValue(registerRequest.Address.AddressLine1)},
                {DynamoConstants.AddressLine2Key, new AttributeValue(registerRequest.Address.AddressLine2)},
                {DynamoConstants.CityKey, new AttributeValue(registerRequest.Address.City)},
                {DynamoConstants.CountyKey, new AttributeValue(registerRequest.Address.County)},
                {DynamoConstants.PostcodeKey, new AttributeValue(registerRequest.Address.County)}
            });
        }

        public async Task<UserContactInformationResponse> GetUserById(string userId)
        {
            var context = new DynamoDBContext(_dynamoClient);
            var config = new DynamoDBOperationConfig()
            {
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("UserId", ScanOperator.Equal, userId)
                }
            };
            var user = await context.QueryAsync<ContactInformationEntryDynamo>(userId, config).GetRemainingAsync();
            return await UserResponseMapper.AllDetails.Map(await context.QueryAsync<ContactInformationEntryDynamo>(userId, config).GetRemainingAsync());
        }

        public async Task<UserContactInformationResponse> GetEntryInContactInformation(string userId, string key)
        {
            var user = await GetUserById(userId);
            return UserResponseMapper.PartialDetails.Map(user, key);
        }
    }
}