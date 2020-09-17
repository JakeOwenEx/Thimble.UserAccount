using System.Threading.Tasks;
using Alba;
using Xunit;

namespace UserAccount.IntegrationTests.UserAccountController.GetPartialContactInfo
{
    public class WhenInvalidPartialContactInfoRequestProvided : ApiTestBase
    {
        private const string ValidUserId = "1c80619c-722e-4729-8f71-fade0268a30d";
        private const string ValidKey = "Email";
        
        public WhenInvalidPartialContactInfoRequestProvided(ApiFixture app) : base(app)
        {
        }
        
        [Fact]
        public async Task Should_Return_404_If_User_Does_Not_Exist()
        {
            await System.Scenario(_ =>
            {
                _.Get.Url($"/useraccount/fake-user/contactInformation/{ValidKey}");

                _.StatusCodeShouldBe(404);
            });
        }
        
        [Fact]
        public async Task Should_Return_400_When_Invalid_Key_Provided()
        {
            await System.Scenario(_ =>
            {
                _.Get.Url($"/useraccount/{ValidUserId}/contactInformation/invalid-key");

                _.StatusCodeShouldBe(400);
            });
        }
    }
}