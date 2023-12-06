using Application;
using Carter;
using Persistence;

var allowedSpecificOrigins = "allowedSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:4200");
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddCarter();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCarter();
app.UseCors(allowedSpecificOrigins);

app.Run();
