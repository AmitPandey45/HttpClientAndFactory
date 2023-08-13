using Api.Versioning.SwaggerConfiguration;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Versioning.Extensions
{
    public static class SwaggerGenOptionsExtension
    {
        public static IServiceCollection ConfigureSwagger(this SwaggerGenOptions options, IServiceCollection services)
        {
            var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, new OpenApiInfo
                {
                    Title = ".Net 6 Versioning API demo",
                    Version = description.ApiVersion.ToString()
                });

                if (description.IsDeprecated)
                {
                    options.OperationFilter<DeprecatedOperationFilter>();
                }
            }

            return services;
        }
    }
}
