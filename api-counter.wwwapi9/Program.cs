using api_counter.wwwapi9.Data;
using api_counter.wwwapi9.Endpoints;
using api_counter.wwwapi9.Models;
using Scalar.AspNetCore;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Demo API");
    });
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

CounterHelper.Initialize();
app.ConfigureCounterHelper();

//Super Optional Extension #1 - Refactor the code!
// Refactor - add a repository layer: interface & concrete class, inject this into the endpoint using the builder.Service

//Super Optional Extension #2
//Create a new endpoint that passes a json collection of strings to a controller method and adds them as new Counters with an appropriate unique integer id AND a value of 0.





app.Run();
