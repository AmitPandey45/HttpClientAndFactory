using Api.Versioning.Configuration;

(WebApplicationBuilder builder, WebApplication app) = Startup.AppStartup(args);
app.Run();