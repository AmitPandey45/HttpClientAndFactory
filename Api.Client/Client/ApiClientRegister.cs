using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace Api.Client.Client
{
    public static class ApiClientRegister
    {
        public static IServiceCollection AddApiClient(
            this IServiceCollection services,
            Action<HttpClient> clientConfiguration)
        {
            services.AddTransient<HttpContextMiddleware>();
            services.AddHttpClient<ApiClient>(clientConfiguration)
                .AddHttpMessageHandler<HttpContextMiddleware>()
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(3)))
                .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(5, TimeSpan.FromSeconds(20)));

            return services;
        }
    }
}
