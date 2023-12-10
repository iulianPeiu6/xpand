using Application;
using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Persistence;
using Domain.Exceptions;
using PlanetExplorationManagement.Api.Models;
using Domain;
using System.Net;

var allowedSpecificOrigins = "allowedSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddCarter();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.Authority = $"https://{builder.Configuration["Auth0:Domain"]}/";
    options.Audience = builder.Configuration["Auth0:Audience"];
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanUpdatePlanetExploration", policy => policy.RequireClaim("permissions", "update:planet-exploration"));
});
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    try
    {
        await next.Invoke();
    }
    catch (ApiErrorException apiErrorException)
    {
        context.Response.StatusCode = (int)apiErrorException.StatusCode;
        await context.Response.WriteAsJsonAsync(new ErrorResponse
        {
            Error = apiErrorException.Error
        });
    }
    catch (Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsJsonAsync(new ErrorResponse
        {
            Error = new Error
            {
                Code = "UnexpectedError",
                Message = exception.Message,
            }
        });
    }
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapCarter();
app.UseCors(allowedSpecificOrigins);

app.Run();
