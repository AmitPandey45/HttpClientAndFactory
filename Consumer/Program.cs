using Api.Client.Client;
using Consumer.Client;

namespace Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<HttpContextMiddleware>();
            builder.Services.BeforeBuildConfigureServices(builder.Configuration);

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddHttpClient();
            builder.Services.AddHttpClient("NamedHttpClient");
            builder.Services.AddHttpClient("NameHttpClientWithConfiguration", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7293");
                client.DefaultRequestHeaders.Add("StartupHeader", Guid.NewGuid().ToString());
            })
                .AddHttpMessageHandler<HttpContextMiddleware>();

            builder.Services.AddHttpClient<CustomHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7293");
            })
                .AddHttpMessageHandler<HttpContextMiddleware>()
                .SetHandlerLifetime(TimeSpan.FromSeconds(1));

            builder.Services.AddApiClient(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7293");
            });

            builder.Services.AddApiClient(client =>
            {
                client.BaseAddress = new Uri("http://api.weatherapi.com/v1/current.json");
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var app = builder.Build();

            builder.Services.AfterBuildConfigureServices(builder.Configuration);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}