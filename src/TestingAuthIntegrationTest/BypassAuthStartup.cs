using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;
using TestingAuth;

namespace TestingAuthIntegrationTest
{
    internal class BypassAuthStartup: Startup
    {
        public override void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<BypassAuthMiddleware>();
            base.Configure(app, loggerFactory);
        }
    }
}