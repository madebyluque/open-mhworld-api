namespace OpenMHWorld.API.Extensions;

public static class CorsExtension
{
    public static IApplicationBuilder ConfigureCors(this IApplicationBuilder app)
    {
        app.UseCors(x => x
           .AllowAnyMethod()
           .AllowAnyHeader()
           .SetIsOriginAllowed(origin => true)
           .AllowCredentials());

        return app;
    }
}
