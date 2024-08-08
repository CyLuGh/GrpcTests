using NLog;
using NLog.Web;
using Splat;
using Splat.NLog;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
Locator.CurrentMutable.UseNLogWithWrappingFullLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddGrpc();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.MapGrpcService<DemoService.Services.DemoService>();
    app.MapGet(
        "/",
        () =>
            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"
    );

    await app.RunAsync();
}
catch (Exception exc)
{
    logger.Error(exc, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
