using OpenMHWorld.API.Extensions;
using OpenMHWorld.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.ConfigureSwagger();
builder.Host.ConfigureSerilog(builder.Configuration);
builder.Services.ConfigureApiVersioning();
builder.Services.ConfigureFirebase(builder.Configuration);

var app = builder.Build();

app.ConfigureCors();
app.UseSwaggerAndUI();
app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
