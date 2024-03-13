using Asp.Versioning;

namespace OpenMHWorld.API.Extensions;

public static class ApiVersioningExtension
{
    public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1, 0);
            x.ReportApiVersions = true;
            x.AssumeDefaultVersionWhenUnspecified = true;
        });

        return services;
    }
}
