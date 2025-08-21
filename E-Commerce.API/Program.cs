using E_Commerce.API.Middlewares;
using E_Commerce.Core;
using E_Commerce.Core.Mappers;
using E_Commerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
// Add infrastructure services to the container.
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the service collection

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

//FluentValidation
builder.Services.AddFluentValidationAutoValidation();
//Add API explorer services
builder.Services.AddEndpointsApiExplorer();
//Add swagger generation services to create swagger specification
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    });
});
//Build the web application
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
//Routing
app.UseRouting();
app.UseSwagger();  //Adds endpoint that can serve the swagger.json
app.UseSwaggerUI();
app.UseCors();


//Auth
app.UseAuthentication();
app.UseAuthorization();

// Map controllers to routes
app.MapControllers();

app.Run();
