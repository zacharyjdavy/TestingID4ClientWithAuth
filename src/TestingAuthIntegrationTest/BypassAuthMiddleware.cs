using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestingAuthIntegrationTest
{
    public class BypassAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BypassAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.User.AddIdentity(new ClaimsIdentity("password"));
            await _next.Invoke(httpContext);
        }
    }
}