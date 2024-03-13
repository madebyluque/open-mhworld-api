using Serilog;
using Serilog.Sinks.Discord;

namespace OpenMHWorld.API.Extensions;

public static class SerilogExtension
{
    public static ConfigureHostBuilder ConfigureSerilog(this ConfigureHostBuilder host, IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Warning()
            .Enrich.FromLogContext()
            .WriteTo.Discord(Convert.ToUInt64(configuration["Discord:WebhookId"]), configuration["Discord:WebhookToken"])
            .CreateLogger();

        host.UseSerilog(Log.Logger);

        return host;
    }
}
