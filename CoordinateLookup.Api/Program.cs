using CoordinateLookup.Business.Concrete;
using CoordinateLookup.Business.DependencyResolvers.Microsoft;
using CoordinateLookup.Business.ValidationRules.FluentValidation;
using CoordinateLookup.Data;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.WebHost.UseUrls("http://*:8080");

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

Env.Load();

var connectionString = Environment.GetEnvironmentVariable("CoordinateLookupDB_Connection_String") ?? throw new InvalidOperationException("Connection string not found."); 

builder.Services.AddDbContext<CoordinateLookupDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddValidatorsFromAssemblyContaining<CoordinatesDtoValidator>();

// Register Services
builder.Services.ContainerDependencies();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<LocationSeederService>();
    await seeder.SeedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
