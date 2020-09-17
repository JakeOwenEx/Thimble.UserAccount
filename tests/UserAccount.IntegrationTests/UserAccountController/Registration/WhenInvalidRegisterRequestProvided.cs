using System.Threading.Tasks;
using Alba;
using Thimble.UserAccount.Controllers.Models.Address;
using Thimble.UserAccount.Controllers.Models.Name;
using Thimble.UserAccount.Controllers.Models.Registration;
using Xunit;

namespace UserAccount.IntegrationTests.UserAccountController.Registration
{
    public class WhenInvalidRegisterRequestProvided : ApiTestBase
    {
        private readonly RegisterUserRequest _registrationRequest;
        
        public WhenInvalidRegisterRequestProvided(ApiFixture app) : base(app)
        {
            _registrationRequest = CreateUser();
        }
        
        [Fact]
        public async Task When_Invalid_UserId_Provided()
        {
            _registrationRequest.UserId = "fake-user-id";
            await System.Scenario(_ =>
            {
                _.Body.JsonInputIs(_registrationRequest);
                
                _.Post.Url("/useraccount/register");

                _.StatusCodeShouldBe(404);
            });
        }
        
        [Theory]
        [InlineData("43543")]
        [InlineData("phone")]
        [InlineData("07 530 4130")]
        public async Task When_Invalid_Phone_Provided(string phone)
        {
            _registrationRequest.PhoneNumber = phone;
            await System.Scenario(_ =>
            {
                _.Body.JsonInputIs(_registrationRequest);
                
                _.Post.Url("/useraccount/register");

                _.StatusCodeShouldBe(400);
            });
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("sadfkhjadskgjfhsdkjghksaljdhgfasdjklhfglkasdjhsadfkhjadskgjfhsdksadfkhjadskgjfhsdkjghksaljdhgfasdj" +
                    "klhfglkasdjhjghksaljdhgfasdjklhfglkasdjhsadfkhjadskgjfhsdkjghksaljdhgfasdjklhfglkasdjh")]
        public async Task When_Invalid_Name_Provided(string firstName)
        {
            _registrationRequest.Name.FirstName = firstName;
            await System.Scenario(_ =>
            {
                _.Body.JsonInputIs(_registrationRequest);
                
                _.Post.Url("/useraccount/register");

                _.StatusCodeShouldBe(400);
            });
        }
        
        private RegisterUserRequest CreateUser()
        {
            return new RegisterUserRequest
            {
                UserId = "1c80619c-722e-4729-8f71-fade0268a30d",
                Name = new NameRequest
                {
                    FirstName = "TEST",
                    LastName = "USER"
                },
                PhoneNumber = "07929475934",
                Address = new AddressRequest
                {
                    AddressLine1 = "TEST-ADDRESS-LINE-1",
                    AddressLine2 = "TEST-ADDRESS-LINE-2",
                    County = "TEST-COUNTY",
                    City = "TEST-CITY",
                    Postcode = "TEST-POSTCODE"
                }
            };
        }
    }
}