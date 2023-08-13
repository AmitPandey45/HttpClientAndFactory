using Api.Versioning.Extensions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;

namespace Api.Versioning.Configuration
{
    public static class Startup
    {
        public static (WebApplicationBuilder builder, WebApplication app) AppStartup(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            IServiceCollection services = ConfigureServices(builder, args);
            WebApplication app = ConfigureMiddleware(builder, args);

            return (builder, app);
        }

        public static IServiceCollection ConfigureServices(WebApplicationBuilder builder, string[] args)
        {
            IServiceCollection services = builder.Services;

            // Add services to the container.

            services.AddControllers();

            services.ConfigureApiVersioning();

            return services;
        }

        public static WebApplication ConfigureMiddleware(WebApplicationBuilder builder, string[] args)
        {
            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            app.ConfigureSwaggerInOrderAsLatestVersionFirst();

            // app.UseRequestLocalization(options);

            app.UseStaticFiles();

            // app.UseMiddleware<LocalizerMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
