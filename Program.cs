using TestProject.Configuration;

var builder = WebApplication.CreateBuilder(args);

var mainSettings = Settings.Load<MainSettings>("Main");
var swaggerSettings = Settings.Load<SwaggerSettings>("Swagger");

// Add services to the container.

builder.Services.AddControllers();

builder.AddAppLogger();

var services = builder.Services;
services.AddAppCors();
services.AddAppVersioning();
services.AddAppSwagger(mainSettings, swaggerSettings);
services.AddAppControllerAndViews();

services.RegisterAppServices();

var app = builder.Build();

app.UseAppSwagger();
app.UseAppControllerAndViews();

app.Run();
