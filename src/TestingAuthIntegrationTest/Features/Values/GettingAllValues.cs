using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TestingAuth;
using Xunit;

namespace TestingAuthIntegrationTest.Features.Values
{
    public class GettingAllValues
    {
        [Fact]
        public async Task WhenAuthorized_ItGetAnOkResponse()
        {
            var hostBuilder = new WebHostBuilder().UseStartup<BypassAuthStartup>();
            var server = new TestServer(hostBuilder);
            var client = server.CreateClient();
            var response = await client.GetAsync("/api/values");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task WhenUnauthorized_ItGetAnUnauthorizedResponse()
        {
            var hostBuilder = new WebHostBuilder().UseStartup<Startup>();
            var server = new TestServer(hostBuilder);
            var client = server.CreateClient();
            var response = await client.GetAsync("/api/values");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
