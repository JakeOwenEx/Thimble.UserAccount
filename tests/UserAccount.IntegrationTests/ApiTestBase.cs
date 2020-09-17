using Alba;
using Xunit;

namespace UserAccount.IntegrationTests
{
    public abstract class ApiTestBase : IClassFixture<ApiFixture>
    {
        protected readonly SystemUnderTest System;

        protected ApiTestBase(ApiFixture app)
        {
            System = app.SystemUnderTest;
        }
    }
}