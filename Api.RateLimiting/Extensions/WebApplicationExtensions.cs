using AspNetCoreRateLimit;

namespace Api.RateLimiting.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication UseIpAddressRateLimiting(this WebApplication app)
        {
            app.UseIpRateLimiting();

            return app;
        }
    }
}
