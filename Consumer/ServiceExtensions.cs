using Microsoft.AspNetCore.Mvc;

namespace Consumer
{
    public static class ServiceExtensions
    {
        public static IServiceCollection BeforeBuildConfigureServices(this IServiceCollection services, [FromServices] IConfiguration configuration)
        {
            // checking config values are available before service build or not
            string value1 = configuration["Key1"];
            string value2 = configuration["Key2"];

            return services;
        }

        public static IServiceCollection AfterBuildConfigureServices(this IServiceCollection services, [FromServices] IConfiguration configuration)
        {
            // checking config values are available after service build or not
            string value1 = configuration["Key1"];
            string value2 = configuration["Key2"];

            return services;
        }
    }
}
