using System.Text.Json.Serialization;
using Serilog;
using Wolverine;
using Wolverine.PoC.Application;
using Wolverine.PoC.Infrastructure;

const int EXIT_FAILURE = 1;
const int EXIT_SUCCESS = 0;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddEnvironmentVariables("CONFIG_");

builder.Host.UseSerilog((_, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(builder.Configuration));

builder.Host.UseWolverine(wolverineConfig =>
{
    wolverineConfig.Discovery.AddApplication();
    wolverineConfig.Discovery.AddInfrastructure();
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

try
{
    Log.Information("Starting host...");

    var app = builder.Build();

    app.UseInfrastructure();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    await app.RunAsync();

    return EXIT_SUCCESS;
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host terminated unexpectedly");

    return EXIT_FAILURE;
}
finally
{
    Log.CloseAndFlush();
}
