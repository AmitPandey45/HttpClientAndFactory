namespace Api.Versioning.SwaggerConfiguration
{
    using Microsoft.AspNetCore.Mvc.Abstractions;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Linq;

    public class DeprecatedOperationFilter : IOperationFilter
    {
        private readonly IApiVersionDescriptionProvider _versionDescriptionProvider;

        public DeprecatedOperationFilter(IApiVersionDescriptionProvider versionDescriptionProvider)
        {
            _versionDescriptionProvider = versionDescriptionProvider;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescription = context.ApiDescription;
            var apiVersion = apiDescription.GetApiVersion();

            if (apiVersion != null)
            {
                var versionDescription = _versionDescriptionProvider.ApiVersionDescriptions.FirstOrDefault(d => d.ApiVersion == apiVersion);

                //if (versionDescription != null && versionDescription.IsDeprecated)
                //{
                //    operation.Deprecated = true;
                //    operation.Description += $" (Deprecated API version: {apiVersion})";
                //}

                if (versionDescription != null)
                {
                    if (versionDescription.ApiVersion.ToString() != apiVersion.ToString())
                    {
                        Console.WriteLine($"============= versionDescription.ApiVersion = {versionDescription.ApiVersion} and apiVersion = {apiVersion} are not equal =============================");
                    }

                    var actionApiVersionModel = apiDescription.ActionDescriptor.GetApiVersionModel();

                    if (actionApiVersionModel.DeprecatedApiVersions.Contains(versionDescription.ApiVersion))
                    {
                        operation.Deprecated = true;
                        operation.Description += $" (Deprecated API version: {apiVersion})";
                    }
                }
            }
        }
    }

}
