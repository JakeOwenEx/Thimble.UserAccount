using System.Threading.Tasks;
using Alba;
using Thimble.UserAccount.Controllers.Models.Address;
using Thimble.UserAccount.Controllers.Models.Name;
using Thimble.UserAccount.Controllers.Models.Registration;
using Xunit;

namespace UserAccount.IntegrationTests.UserAccountController.Registration
{
    public class WhenValidRegisterRequestProvided : ApiTestBase
    {
        private const string TestUserId = "1c80619c-722e-4729-8f71-fade0268a30d";

        public WhenValidRegisterRequestProvided(ApiFixture app) : base(app)
        {
        }

        [Fact]
        public async Task Should_return_registration_response()
        {
            await System.Scenario(_ =>
            {
                _.Body.JsonInputIs(CreateUser());
                
                _.Post.Url("/useraccount/register");

                _.StatusCodeShouldBeOk();

            });
        }
        
        private RegisterUserRequest CreateUser()
        {
            return new RegisterUserRequest
            {
                UserId = TestUserId,
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
