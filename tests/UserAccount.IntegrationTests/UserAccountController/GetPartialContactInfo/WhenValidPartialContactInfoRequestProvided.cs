using System.Threading.Tasks;
using Alba;
using Xunit;

namespace UserAccount.IntegrationTests.UserAccountController.GetPartialContactInfo
{
    public class WhenValidPartialContactInfoRequestProvided : ApiTestBase
    {
        private const string ValidUserId = "1c80619c-722e-4729-8f71-fade0268a30d";
        private const string ValidKey = "Email";
        
        public WhenValidPartialContactInfoRequestProvided(ApiFixture app) : base(app)
        {
        }
        
        [Fact]
        public async Task Should_return_registration_response()
        {
            await System.Scenario(_ =>
            {
                _.Get.Url($"/useraccount/{ValidUserId}/contactInformation/{ValidKey}");

                _.StatusCodeShouldBeOk();
            });
        }
    }
}