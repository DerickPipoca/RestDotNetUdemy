using Microsoft.EntityFrameworkCore;
using RestDotNetUdemy.Models.Context;
using RestDotNetUdemy.Business;
using RestDotNetUdemy.Business.Implementations;
using Serilog;
using MySqlConnector;
using EvolveDb;
using RestDotNetUdemy.Repository.Generic;
using System.Net.Http.Headers;
using Microsoft.Net.Http.Headers;
using RestDotNetUdemy.Hypermedia.Filters;
using RestDotNetUdemy.Hypermedia.Enricher;

var builder = WebApplication.CreateBuilder(args);

// Add Business to the container.
builder.Services.AddControllers();

string? connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];

builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 4, 4)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

var filterOptions = new HyperMediaFilterOptions();
filterOptions.ContentResponseEnricherList.Add(new PersonEnricher());
filterOptions.ContentResponseEnricherList.Add(new BookEnricher());

builder.Services.AddSingleton(filterOptions);

// Versioning API
builder.Services.AddApiVersioning();

// Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute("DefaultApi", "{controller=values}/v{version=apiVersion}/{id?}");

app.Run();

void MigrateDatabase(string? connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed " + ex);
        throw;
    }
}