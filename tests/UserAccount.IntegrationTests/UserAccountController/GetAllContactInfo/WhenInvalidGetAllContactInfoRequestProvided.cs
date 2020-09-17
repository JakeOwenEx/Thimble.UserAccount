using System.Threading.Tasks;
using Alba;
using Xunit;

namespace UserAccount.IntegrationTests.UserAccountController.GetAllContactInfo
{
    public class WhenInvalidGetAllContactInfoRequestProvided : ApiTestBase
    {
        public WhenInvalidGetAllContactInfoRequestProvided(ApiFixture app) : base(app)
        {
        }
        
        [Fact]
        public async Task Should_return_registration_response()
        {
            await System.Scenario(_ =>
            {
                _.Get.Url("/useraccount/fake-user/contactInformation");

                _.StatusCodeShouldBe(404);
            });
        }
    }
}