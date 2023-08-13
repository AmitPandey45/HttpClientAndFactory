using Api.Versioning.SwaggerConfiguration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Versioning.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version"),
                    new QueryStringApiVersionReader("api-version"),
                    new MediaTypeApiVersionReader("x-api-version")
                    );
            });

            services.ConfigureSwagger();

            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // Add ApiExplorer to discover versions
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                options.ConfigureSwagger(services);
            });

            // services.ConfigureOptions<ConfigureSwaggerOptions>();

            // Add Swagger documentation
            ////services.AddSwaggerGen(c =>
            ////{
            ////    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            ////    foreach (var description in provider.ApiVersionDescriptions)
            ////    {
            ////        c.SwaggerDoc(description.GroupName, new OpenApiInfo
            ////        {
            ////            Title = ".Net6 Web API Versioning Demo",
            ////            Version = description.ApiVersion.ToString(),
            ////            Description = description.IsDeprecated ? "This API version has been deprecated. Please use one of the new APIs available from the explorer." : ""
            ////        });
            ////    }
            ////});

            // Add Swagger documentation
            //services.AddSwaggerGen(c =>
            //{
            //    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

            //    foreach (var description in provider.ApiVersionDescriptions)
            //    {
            //        c.SwaggerDoc(description.GroupName, new OpenApiInfo
            //        {
            //            Title = "Your API Title",
            //            Version = description.ApiVersion.ToString()
            //        });

            //        if (description.IsDeprecated)
            //        {
            //            c.OperationFilter<DeprecatedOperationFilter>();
            //        }
            //    }
            //});

            return services;
        }
    }
}
