using Microsoft.AspNetCore.Diagnostics;
using OpenMHWorld.API.Responses;
using Serilog;
using System.Net;

namespace OpenMHWorld.API.Middlewares;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    Log.Error("Something went wrong: {Error}", contextFeature.Error);
                    await context.Response.WriteAsync(new CustomResponse(false, null, "Internal Server Error.").ToString());
                }
            });
        });
    }
}
